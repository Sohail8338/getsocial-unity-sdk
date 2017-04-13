#include "GetSocialBridgeUtils.h"
#include "UnityInvitePlugin.h"
#include "GetSocialJsonUtils.h"
#include "GetSocialFunctionDefs.h"
#include <GetSocial/GetSocial.h>
#include <GetSocial/GetSocialAccessHelper.h>

#pragma clang diagnostic push
#pragma ide diagnostic ignored "OCUnusedGlobalDeclarationInspection"
extern "C" {
NS_ASSUME_NONNULL_BEGIN

#pragma mark - Initialization
void _init(VoidCallbackDelegate completeCallback, void *onCompletePtr,
        FailureCallbackDelegate failureCallback, void *onFailurePtr)
{
    [GetSocialAccessHelper initWithSuccess:^{
        completeCallback(onCompletePtr);
    }                              failure:^(NSError *error) {
        char *err = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
        failureCallback(onFailurePtr, err);
    }];
}

bool _isInitialized()
{
    return [GetSocial isInitialized];
}

void _getReferralData(FetchReferralDataCallbackDelegate fetchReferralDataCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr)
{
    [GetSocial referralDataWithSuccess:^(GetSocialReferralData *referralData) {
                NSString *referralDataJson = [GetSocialJsonUtils serializeReferralData:referralData];
                fetchReferralDataCallback(onSuccessActionPtr, [GetSocialBridgeUtils createCStringFrom:referralDataJson]);
            }
                               failure:^(NSError *error) {
                                   char *serializedError = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
                                   failureCallback(onFailureActionPtr, serializedError);
                               }];
}

char *_getNativeSdkVersion()
{
    return [GetSocialBridgeUtils createCStringFrom:[GetSocial sdkVersion]];
}

#pragma mark - Localization
char *_getLanguage()
{
    return [GetSocialBridgeUtils createCStringFrom:[GetSocial language]];
}

bool _setLanguage(const char *languageCode)
{
    NSString *languageCodeStr = [GetSocialBridgeUtils createNSStringFrom:languageCode];
    return [GetSocial setLanguage:languageCodeStr];
}

#pragma mark - Global error handler
bool _setGlobalErrorListener(void *onErrorActionPtr, GlobalErrorCallbackDelegate errorCallback)
{
    return [GetSocial setGlobalErrorHandler:^(NSError *error) {
        const char *serializedErr = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
        errorCallback(onErrorActionPtr, serializedErr);
    }];
}

bool _removeGlobalErrorListener()
{
    return [GetSocial removeGlobalErrorHandler];
}

#pragma mark - Invites
char *_getInviteChannels()
{
    NSArray<GetSocialInviteChannel *> *channels = [GetSocial inviteChannels];
    NSString *channelsJson = [GetSocialJsonUtils serializeInviteChannelsList:channels];

    return [GetSocialBridgeUtils createCStringFrom:channelsJson];
}

void _sendInvite(const char *channelId,
        VoidCallbackDelegate completeCallback, void *onCompletePtr, void *onCancelPtr,
        FailureCallbackDelegate failureCallback, void *onFailurePtr)
{
    NSString *channelIdStr = [GetSocialBridgeUtils createNSStringFrom:channelId];

    [GetSocial sendInviteWithChannelId:channelIdStr success:^{
        completeCallback(onCompletePtr);
    }                           cancel:^{
        completeCallback(onCancelPtr);
    }                          failure:^(NSError *error) {
        char *err = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
        failureCallback(onFailurePtr, err);
    }];
}

void _sendInviteCustom(const char *channelId, const char *customInviteContentJson,
                       VoidCallbackDelegate completeCallback, void *onCompletePtr, void *onCancelPtr,
                       FailureCallbackDelegate failureCallback, void *onFailurePtr)
{
    NSString *channelIdStr = [GetSocialBridgeUtils createNSStringFrom:channelId];
    NSString *customInviteContentJsonStr = [GetSocialBridgeUtils createNSStringFrom:customInviteContentJson];
    
    GetSocialMutableInviteContent *inviteContent = [GetSocialJsonUtils deserializeCustomInviteContent:customInviteContentJsonStr];
    
    [GetSocial sendInviteWithChannelId:channelIdStr inviteContent:inviteContent success:^{
        completeCallback(onCompletePtr);
    }                           cancel:^{
        completeCallback(onCancelPtr);
    }                          failure:^(NSError *error) {
        char *err = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
        failureCallback(onFailurePtr, err);
    }];
}

    
void _sendInviteCustomAndReferralData(const char *channelId, const char *customInviteContentJson, const char *customReferralDataJson,
        VoidCallbackDelegate completeCallback, void *onCompletePtr, void *onCancelPtr,
        FailureCallbackDelegate failureCallback, void *onFailurePtr)
{
    NSString *channelIdStr = [GetSocialBridgeUtils createNSStringFrom:channelId];
    NSString *customInviteContentJsonStr = [GetSocialBridgeUtils createNSStringFrom:customInviteContentJson];
    NSString *customReferralDataJsonStr = [GetSocialBridgeUtils createNSStringFrom:customReferralDataJson];

    GetSocialMutableInviteContent *inviteContent = [GetSocialJsonUtils deserializeCustomInviteContent:customInviteContentJsonStr];
    NSDictionary *customReferralData = [GetSocialJsonUtils deserializeCustomReferralData:customReferralDataJsonStr];

    [GetSocial sendInviteWithChannelId:channelIdStr inviteContent:inviteContent customReferralData:customReferralData success:^{
        completeCallback(onCompletePtr);
    }                           cancel:^{
        completeCallback(onCancelPtr);
    }                          failure:^(NSError *error) {
        char *err = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
        failureCallback(onFailurePtr, err);
    }];
}

bool _registerInviteProviderPlugin(const char *channelId, void *pluginPtr,
        IsAvailableForDeviceDelegate isAvailableForDevice, PresentChannelInterfaceDelegate presentProviderInterface)
{
    NSString *channelIdStr = [GetSocialBridgeUtils createNSStringFrom:channelId];

    UnityInvitePlugin *invitePlugin = [[UnityInvitePlugin alloc] initWithPluginPtr:pluginPtr inviteFriendsDelegate:presentProviderInterface isAvailableForDeviceDelegate:isAvailableForDevice];

    return [GetSocial registerInviteChannelPlugin:invitePlugin forChannelId:channelIdStr];
}

#pragma mark - Invite Callbacks
// Invite Callbacks
void _executeInviteSuccessCallback(void *callback)
{
    // transfer pointer ownership to arc
    // more at: http://stackoverflow.com/questions/7036350/arc-and-bridged-cast
    GetSocialInviteSuccessCallback inviteCompletedCallback = (__bridge GetSocialInviteSuccessCallback) callback;

    inviteCompletedCallback();
}

void _executeInviteCancelledCallback(void *callback)
{
    // transfer pointer ownership to arc
    // more at: http://stackoverflow.com/questions/7036350/arc-and-bridged-cast
    GetSocialInviteCancelCallback inviteCancelledCallback = (__bridge GetSocialInviteCancelCallback) callback;

    inviteCancelledCallback();
}

void _executeInviteFailedCallback(void *callback)
{
    // transfer pointer ownership to arc
    // more at: http://stackoverflow.com/questions/7036350/arc-and-bridged-cast
    GetSocialFailureCallback inviteFailedCallback = (__bridge GetSocialFailureCallback) callback;

    NSError *error = [[NSError alloc] init];
    inviteFailedCallback(error);
}
    
#pragma mark - Push Notifications
    
void _registerForPushNotifications()
{
    [GetSocial registerForPushNotifications];
}
    
void _setNotificationActionListener(void *listener, NotificationActionListener delegate)
{
    [GetSocial setNotificationActionHandler:^BOOL(GetSocialNotificationAction * _Nonnull action) {
        NSString *serialized = [GetSocialJsonUtils serializeNotificationAction:action];
        char * str = [GetSocialBridgeUtils createCStringFrom:serialized];
        return delegate(listener, str);
    }];
}

#pragma mark - User Management

bool _setOnUserChangedListener(void *listener, VoidCallbackDelegate delegate)
{
    return [GetSocialUser setOnUserChangedHandler:^{
        delegate(listener);
    }];
}

bool _removeOnUserChangedListener()
{
    return [GetSocialUser removeOnUserChangedHandler];
}

char *_getUserId()
{
    return [GetSocialBridgeUtils createCStringFrom:[GetSocialUser userId]];
}

char *_getUserDisplayName()
{
    return [GetSocialBridgeUtils createCStringFrom:[GetSocialUser displayName]];
}

void _setUserDisplayName(const char *displayName, VoidCallbackDelegate completeCallback, void *onCompletePtr,
        FailureCallbackDelegate failureCallback, void *onFailurePtr)
{
    [GetSocialUser setDisplayName:[GetSocialBridgeUtils createNSStringFrom:displayName]
                          success:^{
                              completeCallback(onCompletePtr);
                          } failure:^(NSError *error) {
                char *err = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
                failureCallback(onFailurePtr, err);
            }];
}

char *_getUserAvatarUrl()
{
    return [GetSocialBridgeUtils createCStringFrom:[GetSocialUser avatarUrl]];
}

void _setUserAvatarUrl(const char *avatarUrl, VoidCallbackDelegate completeCallback, void *onCompletePtr,
        FailureCallbackDelegate failureCallback, void *onFailurePtr)
{
    [GetSocialUser setAvatarUrl:[GetSocialBridgeUtils createNSStringFrom:avatarUrl]
                        success:^{
                            completeCallback(onCompletePtr);
                        } failure:^(NSError *error) {
                char *err = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
                failureCallback(onFailurePtr, err);
            }];
}

bool _isUserAnonymous()
{
    return [GetSocialUser isAnonymous];
}

char *_getAuthIdentities()
{
    NSDictionary<NSString *, NSString *> *identities = [GetSocialUser authIdentities];
    return [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeUserIdentities:identities]];
}

void _addAuthIdentity(const char *identity,
        VoidCallbackDelegate successCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr,
        OnUserConflictDelegate conflictCallBack, void *onConflictActionPtr)
{
    NSString *identityStr = [GetSocialBridgeUtils createNSStringFrom:identity];
    GetSocialAuthIdentity *gsIdentity = [GetSocialJsonUtils deserializeIdentity:identityStr];
    [GetSocialUser addAuthIdentity:gsIdentity success:^{
        successCallback(onSuccessActionPtr);

    }                     conflict:^(GetSocialConflictUser *conflictUser) {
        NSString *serializedConflictUser = [GetSocialJsonUtils serializeConflictUser:conflictUser];
        conflictCallBack(onConflictActionPtr, [GetSocialBridgeUtils createCStringFrom:serializedConflictUser]);
    }                      failure:^(NSError *error) {
        const char *serializedErr = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
        failureCallback(onFailureActionPtr, serializedErr);
    }];
}

void _switchUser(const char *identity,
        VoidCallbackDelegate successCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr)
{
    NSString *identityStr = [GetSocialBridgeUtils createNSStringFrom:identity];
    GetSocialAuthIdentity *gsIdentity = [GetSocialJsonUtils deserializeIdentity:identityStr];
    [GetSocialUser switchUserToIdentity:gsIdentity success:^{
        successCallback(onSuccessActionPtr);
    }                           failure:^(NSError *error) {
        const char *serializedErr = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
        failureCallback(onFailureActionPtr, serializedErr);
    }];
}

void _removeAuthIdentity(const char *providerId,
        VoidCallbackDelegate successCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr)
{
    NSString *providerIdStr = [GetSocialBridgeUtils createNSStringFrom:providerId];

    [GetSocialUser removeAuthIdentityWithProviderId:providerIdStr success:^{
        successCallback(onSuccessActionPtr);
    }                                       failure:^(NSError *error) {
        const char *serializedErr = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
        failureCallback(onFailureActionPtr, serializedErr);
    }];
}

void _resetInternal()
{
    [GetSocialAccessHelper reset];
}

#pragma mark - SocialGraph

void _addFriend(const char *userId,
        IntCallbackDelegate successCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr)
{
    NSString *userIdStr = [GetSocialBridgeUtils createNSStringFrom:userId];

    [GetSocialUser addFriend:userIdStr
                     success:^(int result) {
                         successCallback(onSuccessActionPtr, result);
                     } failure:^(NSError *error) {
                const char *serializedErr = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
                failureCallback(onFailureActionPtr, serializedErr);
            }];
}

void _removeFriend(const char *userId,
        IntCallbackDelegate successCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr)
{
    NSString *userIdStr = [GetSocialBridgeUtils createNSStringFrom:userId];

    [GetSocialUser removeFriend:userIdStr
                        success:^(int result) {
                            successCallback(onSuccessActionPtr, result);
                        } failure:^(NSError *error) {
                const char *serializedErr = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
                failureCallback(onFailureActionPtr, serializedErr);
            }];
}

void _isFriend(const char *userId,
        BoolCallbackDelegate successCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr)
{
    NSString *userIdStr = [GetSocialBridgeUtils createNSStringFrom:userId];

    [GetSocialUser isFriend:userIdStr
                    success:^(BOOL isFriend) {
                        successCallback(onSuccessActionPtr, isFriend);
                    } failure:^(NSError *error) {
                const char *serializedErr = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
                failureCallback(onFailureActionPtr, serializedErr);
            }];
}

void _getFriendsCount(IntCallbackDelegate successCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr)
{
    [GetSocialUser friendsCountWithSuccess:^(int result) {
        successCallback(onSuccessActionPtr, result);
    }                              failure:^(NSError *error) {
        const char *serializedErr = [GetSocialJsonUtils serializeError:error].UTF8String;
        failureCallback(onFailureActionPtr, serializedErr);
    }];
}

void _getFriends(int offset, int limit,
        StringCallbackDelegate successCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr)
{
    [GetSocialUser friendsWithOffset:offset limit:limit success:^(NSArray<GetSocialPublicUser *> *users) {
        NSString *serializedUsers = [GetSocialJsonUtils serializePublicUserArray:users];
        successCallback(onSuccessActionPtr, [GetSocialBridgeUtils createCStringFrom:serializedUsers]);
    }                        failure:^(NSError *error) {
        const char *serializedErr = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
        failureCallback(onFailureActionPtr, serializedErr);
    }];
}

#pragma mark - Activity Feed API

void _getAnnouncements(const char *feed,
        StringCallbackDelegate successCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr)
{
    NSString *feedId = [GetSocialBridgeUtils createNSStringFrom:feed];

    [GetSocial announcementsForFeed:feedId
                            success:^(NSArray<GetSocialActivityPost *> *posts) {
                                NSString *serializedPosts = [GetSocialJsonUtils serializeActivityPostList:posts];
                                successCallback(onSuccessActionPtr, [GetSocialBridgeUtils createCStringFrom:serializedPosts]);
                            }
                            failure:^(NSError *error) {
                                const char *serializedErr = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
                                failureCallback(onFailureActionPtr, serializedErr);
                            }];
}

void _getActivitiesWithQuery(const char *query,
        StringCallbackDelegate successCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr)
{
    NSString *queryStr = [GetSocialBridgeUtils createNSStringFrom:query];
    GetSocialActivitiesQuery *activitiesQuery = [GetSocialJsonUtils deserializeActivitiesQuery:queryStr];

    [GetSocial activitiesWithQuery:activitiesQuery
                           success:^(NSArray<GetSocialActivityPost *> *posts) {
                               NSString *serializedPosts = [GetSocialJsonUtils serializeActivityPostList:posts];
                               successCallback(onSuccessActionPtr, [GetSocialBridgeUtils createCStringFrom:serializedPosts]);
                           }
                           failure:^(NSError *error) {
                               const char *serializedErr = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
                               failureCallback(onFailureActionPtr, serializedErr);
                           }];
}

void _getActivityById(const char *activityId,
        StringCallbackDelegate successCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr)
{
    NSString *activityIdStr = [GetSocialBridgeUtils createNSStringFrom:activityId];
    [GetSocial activityWithId:activityIdStr
                      success:^(GetSocialActivityPost *post) {
                          NSString *serializedPosts = [GetSocialJsonUtils serializeActivityPost:post];
                          successCallback(onSuccessActionPtr, [GetSocialBridgeUtils createCStringFrom:serializedPosts]);
                      }
                      failure:^(NSError *error) {
                          const char *serializedErr = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
                          failureCallback(onFailureActionPtr, serializedErr);
                      }];
}

void _postActivityToFeed(const char *feedId, const char *activityContent,
        StringCallbackDelegate successCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr)
{
    NSString *feedIdStr = [GetSocialBridgeUtils createNSStringFrom:feedId];
    NSString *activityContentStr = [GetSocialBridgeUtils createNSStringFrom:activityContent];
    GetSocialActivityPostContent *content = [GetSocialJsonUtils deserializeActivityContent:activityContentStr];

    [GetSocial postActivity:content
                     toFeed:feedIdStr
                    success:^(GetSocialActivityPost *post) {
                        NSString *serializedPosts = [GetSocialJsonUtils serializeActivityPost:post];
                        successCallback(onSuccessActionPtr, [GetSocialBridgeUtils createCStringFrom:serializedPosts]);
                    }
                    failure:^(NSError *error) {
                        const char *serializedErr = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
                        failureCallback(onFailureActionPtr, serializedErr);
                    }];
}

void _postCommentToActivity(const char *activityId, const char *comment,
        StringCallbackDelegate successCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr)
{
    NSString *commentStr = [GetSocialBridgeUtils createNSStringFrom:comment];
    GetSocialActivityPostContent *commentContent = [GetSocialJsonUtils deserializeActivityContent:commentStr];

    NSString *activityIdStr = [GetSocialBridgeUtils createNSStringFrom:activityId];

    [GetSocial postComment:commentContent
          toActivityWithId:activityIdStr
                   success:^(GetSocialActivityPost *post) {
                       NSString *serializedPosts = [GetSocialJsonUtils serializeActivityPost:post];
                       successCallback(onSuccessActionPtr, [GetSocialBridgeUtils createCStringFrom:serializedPosts]);
                   }
                   failure:^(NSError *error) {
                       const char *serializedErr = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
                       failureCallback(onFailureActionPtr, serializedErr);
                   }];
}

void _likeActivity(const char *activityId, bool isLiked,
        StringCallbackDelegate successCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr)
{
    NSString *activityIdStr = [GetSocialBridgeUtils createNSStringFrom:activityId];
    [GetSocial likeActivityWithId:activityIdStr
                          isLiked:isLiked
                          success:^(GetSocialActivityPost *post) {
                              NSString *serializedPosts = [GetSocialJsonUtils serializeActivityPost:post];
                              successCallback(onSuccessActionPtr, [GetSocialBridgeUtils createCStringFrom:serializedPosts]);
                          }
                          failure:^(NSError *error) {
                              const char *serializedErr = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
                              failureCallback(onFailureActionPtr, serializedErr);
                          }];
}

void _getActivityLikers(const char *activityId, int offset, int limit,
        StringCallbackDelegate successCallback, void *onSuccessActionPtr,
        FailureCallbackDelegate failureCallback, void *onFailureActionPtr)
{
    NSString *activityIdStr = [GetSocialBridgeUtils createNSStringFrom:activityId];
    [GetSocial activityLikers:activityIdStr
                       offset:offset
                        limit:limit
                      success:^(NSArray<GetSocialPublicUser *> *likers) {
                          NSString *serializedAuthors = [GetSocialJsonUtils serializePublicUserArray:likers];
                          successCallback(onSuccessActionPtr, [GetSocialBridgeUtils createCStringFrom:serializedAuthors]);
                      }
                      failure:^(NSError *error) {
                          const char *serializedErr = [GetSocialBridgeUtils createCStringFrom:[GetSocialJsonUtils serializeError:error]];
                          failureCallback(onFailureActionPtr, serializedErr);
                      }];
}

#pragma mark - Hades Configuration
void _setHadesConfigurationInternal(int hadesConfigurationType)
{
    [GetSocialAccessHelper setHadesConfigurationInt:hadesConfigurationType];
}

int _getCurrentHadesConfigurationInternal()
{
    return [GetSocialAccessHelper currentHadesConfigurationInt];
}

NS_ASSUME_NONNULL_END
}

#pragma clang diagnostic pop
