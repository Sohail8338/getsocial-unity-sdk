using System;
using System.Collections.Generic;
using System.Linq;
using GetSocialSdk.Core;
using GetSocialSdk.Ui;
using UnityEngine;

public class AnnouncementsSection : BaseListSection<AnnouncementsQuery, Activity>
{
    public AnnouncementsQuery Query;
    public bool Comments;
    protected override string GetSectionName()
    {
        return "Announcements";
    }

    protected override void Load(PagingQuery<AnnouncementsQuery> query, Action<PagingResult<Activity>> success, Action<GetSocialError> error)
    {
        Communities.GetAnnouncements(query.Query, (result) => {
            var pResult = new PagingResult<Activity>
            {
                Entries = result
            };
            success(pResult);
        }, error);
    }

    protected override void Count(AnnouncementsQuery query, Action<int> success, Action<GetSocialError> error)
    {
        // Not supported
    }

    protected override bool HasQuery()
    {
        return false;
    }

    protected override void DrawItem(Activity item)
    {
        GUILayout.Label(item.Author.DisplayName, GSStyles.BigLabelText);
        GUILayout.Label(item.Text, GSStyles.NormalLabelText);
        if (item.Button != null)
        {
            DemoGuiUtils.DrawButton(item.Button.Title, () =>
            {
                _console.LogD("Handling: " + item.Button.ToString());
                GetSocial.Handle(item.Button.Action);
            }, style: GSStyles.Button);
        }

        DemoGuiUtils.DrawButton("Actions", () => ShowActions(item), style: GSStyles.Button);
    }

    private void ShowActions(Activity activity)
    {
        var popup = Dialog().WithTitle("Actions");
        popup.AddAction("Info", () => _console.LogD(activity.ToString()));
        popup.AddAction("Details View", () => Details(activity));
        if (activity.Source.IsActionAllowed(CommunitiesAction.React))
        {
            popup.AddAction("React", () => React(activity));
        }
        popup.AddAction("Reactions", () => ListReactions(activity));
        if (!Comments)
        {
            popup.AddAction("Comments", () => ShowComments(activity));
            if (activity.Source.IsActionAllowed(CommunitiesAction.Comment))
            {
                popup.AddAction("Post Comment", () => PostComment(activity));
            }
        }
        if (activity.Author.Id.Equals(GetSocial.GetCurrentUser().Id))
        {
            popup.AddAction("Edit", () => Edit(activity));
            popup.AddAction("Remove", () => Remove(activity));
        }
        popup.AddAction("Cancel", () => { });
        popup.Show();
    }

    private void PostComment(Activity activity)
    {
        demoController.PushMenuSection<PostActivitySection>(section =>
        {
            section.Target = PostActivityTarget.Comment(activity.Id);
        });
    }

    private void Edit(Activity activity)
    {
        demoController.PushMenuSection<PostActivitySection>(section =>
        {
            section.SetActivity(activity);
            section.Target = PostActivityTarget.Topic(Query.Ids.Ids.ToArray()[0]);
        });
    }

    private void Remove(Activity activity)
    {
        List<string> list = new List<string>();
        list.Add(activity.Id);
        var query = RemoveActivitiesQuery.ActivityIds(list);
        Communities.RemoveActivities(query, () =>
        {
            var index = _items.FindIndex(item => item == activity);
            _items.RemoveAt(index);
            _console.LogD("Activity removed");
        }, error => _console.LogE("Failed to remove: " + error.Message));
    }

    private void Details(Activity activity)
    {
        ActivityDetailsViewBuilder.Create(activity.Id)
            .SetViewStateCallbacks(() => _console.LogD("Feed opened"), () => _console.LogD("Feed closed"))
            .SetActionListener(OnAction)
            .SetMentionClickListener(OnMentionClicked)
            .SetAvatarClickListener(OnUserAvatarClicked)
            .SetTagClickListener(OnTagClicked)
            .SetUiActionListener(OnUiAction)
            .Show();
    }

    private void ShowComments(Activity activity)
    {
        demoController.PushMenuSection<ActivitiesSection>(section =>
        {
            section.Comments = true;
            section.Query = ActivitiesQuery.CommentsToActivity(activity.Id);
        });
    }

    private void ListReactions(Activity activity)
    {
        demoController.PushMenuSection<ReactionsListSection>(section =>
        {
            section.Activity = activity;
        });
    }

    private void React(Activity activity)
    {
        var popup = Dialog().WithTitle("Actions");
        var reactions = new List<string> { Reactions.Like, Reactions.Angry, Reactions.Haha, Reactions.Love, Reactions.Sad, Reactions.Wow };
        foreach (var reaction in reactions)
        {
            popup.AddAction(reaction, () =>
            {
                Communities.AddReaction(reaction, activity.Id, () =>
                {
                    Refresh(activity);
                    _console.LogD("Reacted to activity", false);
                }, error => _console.LogE(error.ToString()));
            });
        }

        if (activity.MyReactions.Count > 0)
        {
            popup.AddAction("Delete Reaction", () =>
            {
                Communities.RemoveReaction(activity.MyReactions.First(), activity.Id, () =>
                {
                    Refresh(activity);
                    _console.LogD("Reacted to activity", false);
                }, error => _console.LogE(error.ToString()));
            });
        }
        popup.AddAction("Cancel", () => { });
        popup.Show();
    }

    private void Refresh(Activity activity)
    {
        Communities.GetActivity(activity.Id, refreshed =>
        {
            _items[_items.FindIndex(item => item == activity)] = refreshed;
        }, error => _console.LogE(error.ToString()));
    }

    protected override AnnouncementsQuery CreateQuery(QueryObject queryObject)
    {
        return Query;
    }

    private void OnMentionClicked(string mention)
    {
        if (mention.Equals(MentionTypes.App))
        {
            _console.LogD("Application mention clicked.");
            return;
        }
        Communities.GetUser(UserId.Create(mention), OnUserAvatarClicked, error => _console.LogE("Failed to get user details, error:" + error.Message));
    }

    private void OnTagClicked(string tag)
    {
        GetSocialUi.CloseView();
        demoController.PushMenuSection<ActivitiesSection>(section =>
        {
            section.Query = ActivitiesQuery.Everywhere().WithTag(tag);
        });
    }

    private void OnUserAvatarClicked(User publicUser)
    {
        if (GetSocial.GetCurrentUser().Id.Equals(publicUser.Id))
        {
            var popup = new MNPopup("Action", "Choose Action");
            popup.AddAction("Show My Feed", () => OpenUserGlobalFeed(publicUser));
            popup.AddAction("Cancel", () => { });
            popup.Show();
        }
        else
        {
            Communities.IsFriend(UserId.Create(publicUser.Id), isFriend =>
            {
                if (isFriend)
                {
                    var popup = new MNPopup("Action", "Choose Action");
                    popup.AddAction("Show " + publicUser.DisplayName + " Feed", () => OpenUserGlobalFeed(publicUser));
                    popup.AddAction("Remove from Friends", () => RemoveFriend(publicUser));
                    popup.AddAction("Cancel", () => { });
                    popup.Show();
                }
                else
                {
                    var popup = new MNPopup("Action", "Choose Action");
                    popup.AddAction("Show " + publicUser.DisplayName + " Feed", () => OpenUserGlobalFeed(publicUser));
                    popup.AddAction("Add to Friends", () => AddFriend(publicUser));
                    popup.AddAction("Cancel", () => { });
                    popup.Show();
                }
            }, error => _console.LogE("Failed to check if friends with " + publicUser.DisplayName + ", error:" + error.Message));
        }
    }

    private void AddFriend(User user)
    {
        Communities.AddFriends(UserIdList.Create(user.Id),
            friendsCount =>
            {
                var message = user.DisplayName + " is now your friend.";
                _console.LogD(message);
            },
            error => _console.LogE("Failed to add a friend " + user.DisplayName + ", error:" + error.Message));
    }

    private void RemoveFriend(User user)
    {
        Communities.RemoveFriends(UserIdList.Create(user.Id),
            friendsCount =>
            {
                var message = user.DisplayName + " is not your friend anymore.";
                _console.LogD(message);
            },
            error => _console.LogE("Failed to remove a friend " + user.DisplayName + ", error:" + error.Message));
    }

    private void OnUiAction(UiAction action, Action pendingAction)
    {
        var forbiddenForAnonymous = new List<UiAction>()
        {
            UiAction.LikeActivity, UiAction.LikeComment, UiAction.PostActivity, UiAction.PostComment
        };
        if (forbiddenForAnonymous.Contains(action) && GetSocial.GetCurrentUser().IsAnonymous)
        {
            var message = "Action " + action + " is not allowed for anonymous.";
            _console.LogD(message);
        }
        else
        {
            pendingAction();
        }
    }

    void OnAction(GetSocialAction action)
    {
        demoController.HandleAction(action);
    }
    private void OpenUserGlobalFeed(User user)
    {
        ActivityFeedViewBuilder.Create(ActivitiesQuery.FeedOf(UserId.Create(user.Id)))
            .SetWindowTitle("Feed of " + user.DisplayName)
            .SetViewStateCallbacks(() => _console.LogD("Feed opened"), () => _console.LogD("Feed closed"))
            .SetActionListener(OnAction)
            .SetMentionClickListener(OnMentionClicked)
            .SetAvatarClickListener(OnUserAvatarClicked)
            .SetTagClickListener(OnTagClicked)
            .SetUiActionListener(OnUiAction)
            .Show();
    }

}
