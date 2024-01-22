var notificationClick = true;

function SendFollow(id) {
    $.ajax({
        url: `/Home/SendFollow/${id}`,
        method: "GET",
        success: function (data) {
            //let element = document.querySelector("#alert");
            //element.style.display = "block";
            //element.innerHTML = "You friend request sent successfully";
            GetAllUsers();
            SendFollowCall(id);
            //setTimeout(() => {
            //    element.innerHTML = "";
            //    element.style.display = "none";
            //}, 5000);
        }
    })
}

function UnFollowCall(id) {
    $.ajax({
        url: `/Home/UnFollowCall?id=${id}`,
        method: "GET",
        success: function (data) {
            GetAllUsers();
            SendFollowCall(id);
        }
    })
}

function ConfirmRequest(senderId, receiverId, requestId) {
    $.ajax({
        url: `/Home/ConfirmRequest?senderId=${senderId}&&requestId=${requestId}`,
        method: "GET",
        success: function (data) {
            SendFollowCall(receiverId);
            SendFollowCall(senderId);
            GetAllUsers();
            //GetMyRequests();
            //let content = "";
            //let subContent = "";
            //console.log(data);
            //for (var i = 0; i < data.length; i++) {

            //}
        }
    })
}


function NotificationClick() {
    if (!notificationClick) {
        $.ajax({
            url: `/Home/DeleteNotification`,
            method: "GET",
            success: function (receiverId) {
                SendFollowCall(receiverId);
                //GetMyRequests();
                //let content = "";
                //let subContent = "";
                //console.log(data);
                //for (var i = 0; i < data.length; i++) {

                //}
            }
        })
    }
    notificationClick = !notificationClick;
}

function NotificationGeneralFormOfInformation(receiverId, requestId) {
    $.ajax({
        url: `/Home/NotificationGeneralFormOfInformation?requestId=${requestId}`,
        method: "GET",
        success: function (data) {
            SendFollowCall(receiverId);
            //GetMyRequests();
            //let content = "";
            //let subContent = "";
            //console.log(data);
            //for (var i = 0; i < data.length; i++) {

            //}
        }
    })
}


function DeleteRequest(id, senderId) {
    $.ajax({
        url: `/Home/DeleteRequest?requestId=${id}&&senderId=${senderId}`,
        method: "GET",

        success: function (data) {
            GetAllUsers();
            GetMyRequests();
            SendFollowCall(senderId);
        }
    })
}

function GetMyRequests() {
    $.ajax({
        url: "/Home/GetAllRequests",
        method: "GET",
        success: function (data) {
            let content = "";
            let requestCount = 0;
            let notificationCount = 0;
            let notificatonsContent = "";
            let subContent = "";
            //console.log(data);
            for (var i = 0; i < data.length; i++) {
                if (data[i].status == "Request") {
                    content += `
                            <div class="item d-flex align-items-center">
                                <div class="figure">
                                    <a href="#"><img src="/assets/images/user/${data[i].sender.imageUrl}" class="rounded-circle" alt="image"></a>
                                </div>

                                <div class="content d-flex justify-content-between align-items-center">
                                    <div class="text">
                                        <h4><a href="#">${data[i].sender.userName}</a></h4>
                                    </div>
                                    <div class="btn-box d-flex align-items-center">
                                        <button class="delete-btn d-inline-block me-2" data-bs-toggle="tooltip" data-bs-placement="top" onclick="DeleteRequest(${data[i].id},'${data[i].senderId}')" title="Delete" type="button"><i class="ri-close-line"></i></button>

                                        <button class="confirm-btn d-inline-block" data-bs-toggle="tooltip" data-bs-placement="top" onclick="ConfirmRequest('${data[i].senderId}','${data[i].receiverId}','${data[i].id}')" title="Confirm" type="button"><i class="ri-check-line"></i></button>
                                    </div>
                                </div>
                            </div>
                           `;

                    subContent += `
                                <div class="item d-flex justify-content-between align-items-center">
                                    <div class="figure">
                                        <a href="#"><img src="/assets/images/user/${data[i].sender.imageUrl}" class="rounded-circle" alt="image"></a>
                                    </div>
                                    <div class="text">
                                        <h4><a href="#">${data[i].sender.userName}</a></h4>
                                        <span>${data[i].content}</span>
                                        <span class="main-color">${data[i].requestTime} Ago</span>
                                    </div>
                                </div>
                                `;

                    notificatonsContent += `
                    
                                       <div class="item d-flex justify-content-between align-items-center">
                                                       <div class="figure">
                                                           <a asp-action="MyProfile" asp-controller="Home"><img src="/assets/images/user/${data[i].sender.imageUrl}" class="rounded-circle" alt="image"></a>
                                                       </div>
                                                       <div class="text">
                                                           <h4><a asp-action="MyProfile" asp-controller="Home">${data[i].sender.userName}</a></h4>
                                                           <span>${data[i].content}</span>
                                                           <span class="main-color">${data[i].requestTime} Ago</span>
                                                       </div>
                                        </div> 
                    `;
                    requestCount += 1;
                    notificationCount += 1;
                }
                else {
                    subContent += `
                                <div class="item d-flex justify-content-between align-items-center">
                                    <div class="figure">
                                        <a href="#"><img src="/assets/images/user/${data[i].sender.imageUrl}" class="rounded-circle" alt="image"></a>
                                    </div>
                                    <div class="text">
                                        <h4><a href="#">${data[i].sender.userName}</a></h4>
                                        <span>${data[i].content}</span>
                                        <span class="main-color">${data[i].requestTime} Ago</span>
                                    </div>
                                </div>
                    
                    `;

                    notificatonsContent += `
                    
                                       <div class="item d-flex justify-content-between align-items-center">
                                                       <div class="figure">
                                                           <a asp-action="MyProfile" asp-controller="Home"><img src="/assets/images/user/${data[i].sender.imageUrl}" class="rounded-circle" alt="image"></a>
                                                       </div>
                                                       <div class="text">
                                                           <h4><a asp-action="MyProfile" asp-controller="Home">${data[i].sender.userName}</a></h4>
                                                           <span>${data[i].content}</span>
                                                           <span class="main-color">${data[i].requestTime} Ago</span>
                                                       </div>
                                                       <div class="icon">
                                                           <a onclick="NotificationGeneralFormOfInformation('${data[i].receiverId}','${data[i].id}')"><i class="flaticon-x-mark"></i></a>
                                                       </div>
                                        </div> 
                    `;
                    notificationCount += 1;
                }
            }
            $("#requests").html(content);
            $("#notifications").html(subContent);
            $("#yourNotifications").html(notificatonsContent);
            $("#userRequestCount").html(requestCount);
            $("#notificationCount").html(notificationCount);
        }
    })
}

function UserRefresh() {
    $.ajax({
        url: `/Home/CurrentUser`,
        method: "GET",
        success: function (user) {
            $(".likeCount").html(user.likeCount);
            $(".followingCount").html(user.followingCount);
            $(".followersCount").html(user.followersCount);
        }
    })
}

function AlreadySent(id) {
    $.ajax({
        url: `/Home/AlreadySent?id=${id}`,
        method: "GET",
        success: function (user) {
            GetAllUsers();
            SendFollowCall(id);
        }
    })
}

function UserMessage(id) {
    $.ajax({
        url: `/Home/UserMessage?id=${id}`,
        method: "GET",

        success: function (friend) {
            let context = ``;
            context += `
                      <div class="live-chat-header d-flex justify-content-between align-items-center">
                          <div class="live-chat-info">
                              <a href="#"><img src="/assets/images/user/${friend.imageUrl}" class="rounded-circle" alt="image"></a>
                              <h3>
                                  <a href="#">${friend.userName}</a>
                              </h3>
                          </div>
                      
                          <ul class="live-chat-right">
                              <li>
                                  <button class="btn d-inline-block" data-bs-toggle="tooltip" data-bs-placement="top" title="Delete" type="button"><i class="ri-delete-bin-line"></i></button>
                              </li>
                          </ul>
                      </div>
                <div class="live-chat-container">

               </div>

                       
            <div class="chat-list-footer">
                <form class="d-flex align-items-center">
                    <div class="btn-box d-flex align-items-center me-3">
                        <button class="file-attachment-btn d-inline-block me-2" data-bs-toggle="tooltip" data-bs-placement="top" title="File Attachment" type="button"><i class="ri-attachment-2"></i></button>

                        <button class="emoji-btn d-inline-block" data-bs-toggle="tooltip" data-bs-placement="top" title="Emoji" type="button"><i class="ri-user-smile-line"></i></button>
                    </div>

                    <input type="text" class="form-control" placeholder="Type your message...">

                    <button type="submit" class="send-btn d-inline-block">Send</button>
                </form>
            </div>
            `;
            $("#liveChatBody").html(context);
        }
    })
}


async function GetAllUsers() {
    $.ajax({
        url: "/Home/GetAllUsers",
        method: "GET",

        success: function (data) {
            //console.log(data);
            var context = "";
            let subContent = "";
            let friendContent = "";
            let liveChatFriend = "";
            let d = "";
            for (var i = 0; i < data.length; i++) {
                if (data[i].isFriend) {
                    subContent = `<button class='btn btn-outline-secondary' onclick="UnFollowCall('${data[i].id}')">UnFollow</button>`;
                    if (data[i].isOnline) {
                        d += `
                    <div class="contact-item">
                        <a href="#"><img src="/assets/images/user/${data[i].imageUrl}" class="rounded-circle" alt="image"></a>
                        <span class="name"><a href="#">${data[i].userName}</a></span>
                        <span class="status-online"></span>
                    </div>
                    `;

                        liveChatFriend += `  
                            <div class="chat-box" style="width:100px;height:100px;margin-left:30px;">
                                       <div class="image">
                                           <a onclick="UserMessage('${data[i].id}')"><img src="/assets/images/user/${data[i].imageUrl}" class="rounded-circle" alt="image"></a>
                                           <span class="status-online"></span>
                                       </div>
                                 <h3>
                                     <a href="#">${data[i].userName}</a>
                                 </h3>
                            </div>     
                        `;
                    }
                    else {
                        d += `
                        <div class="contact-item">
                            <a href="#"><img src="/assets/images/user/${data[i].imageUrl}" class="rounded-circle" alt="image"></a>
                            <span class="name"><a href="#">${data[i].userName}</a></span>
                            <span class="status-offline"></span>
                        </div>
                        `;

                        liveChatFriend += `  
                                   <div class="chat-box" style="width:100px;height:100px;margin-left:30px;">
                                       <div class="image">
                                           <a onclick="UserMessage('${data[i].id}')"><img src="/assets/images/user/${data[i].imageUrl}" class="rounded-circle" alt="image"></a>
                                           <span class="status-offline"></span>
                                       </div>
                                       <h3>
                                           <a href="#">${data[i].userName}</a>
                                       </h3>
                                   </div>
                        `;
                    }

                    friendContent += `
                    
                        <div class="col-lg-3 col-sm-6">
                       <div class="single-friends-card">
                           <div class="friends-image">
                               <a href="#">
                                    <img src="/assets/images/friends/friends-bg-10.jpg" alt="image">
                               </a>
                               <div class="icon">
                                   <a href="#"><i class="flaticon-user"></i></a>
                               </div>
                           </div>
                           <div class="friends-content">
                               <div class="friends-info d-flex justify-content-between align-items-center">
                                   <a href="#">
                                        <img style="width:100px;height:100px" src='/assets/images/user/${data[i].imageUrl}' alt="image">
                                   </a>
                                   <div class="text ms-3">
                                       <h3><a href="#">${data[i].userName}</a></h3>
                                   </div>
                               </div>
                               <ul class="statistics">
                                   <li>
                                       <a href="#">
                                           <span class="item-number">${data[i].likeCount}</span>
                                           <span class="item-text">Likes</span>
                                       </a>
                                   </li>
                                   <li>
                                       <a href="#">
                                           <span class="item-number">${data[i].followingCount}</span>
                                           <span class="item-text">Following</span>
                                       </a>
                                   </li>
                                   <li>
                                       <a href="#">
                                           <span class="item-number">${data[i].followersCount}</span>
                                           <span class="item-text">Followers</span>
                                       </a>
                                   </li>
                               </ul>
                               <div class="button-group d-flex justify-content-between align-items-center">
                                   <div class="add-friend-btn">
                                     ${subContent}
                                   </div>

                                   <div class="send-message-btn">
                                       <button type="submit">Send Message</button>
                                   </div>
                               </div>
                           </div>
                       </div>
                   </div>
                    
                    
                    `;
                }
                else {
                    if (data[i].hasRequestPending) {
                        subContent = `<button onclick="AlreadySent('${data[i].id}')" class='btn btn-outline-secondary'>Already Sent</button>`;
                    }
                    else {
                        subContent = `<button onclick="SendFollow('${data[i].id}')" class='btn btn-outline-primary'>Follow</button>`;
                    }
                    context += `
                    <div class="col-lg-3 col-sm-6">
                       <div class="single-friends-card">
                           <div class="friends-image">
                               <a href="#">
                                    <img src="/assets/images/friends/friends-bg-10.jpg" alt="image">
                               </a>
                               <div class="icon">
                                   <a href="#"><i class="flaticon-user"></i></a>
                               </div>
                           </div>
                           <div class="friends-content">
                               <div class="friends-info d-flex justify-content-between align-items-center">
                                   <a href="#">
                                        <img style="width:100px;height:100px" src='/assets/images/user/${data[i].imageUrl}' alt="image">
                                   </a>
                                   <div class="text ms-3">
                                       <h3><a href="#">${data[i].userName}</a></h3>
                                   </div>
                               </div>
                               <ul class="statistics">
                                   <li>
                                       <a href="#">
                                           <span class="item-number">${data[i].likeCount}</span>
                                           <span class="item-text">Likes</span>
                                       </a>
                                   </li>
                                   <li>
                                       <a href="#">
                                           <span class="item-number">${data[i].followingCount}</span>
                                           <span class="item-text">Following</span>
                                       </a>
                                   </li>
                                   <li>
                                       <a href="#">
                                           <span class="item-number">${data[i].followersCount}</span>
                                           <span class="item-text">Followers</span>
                                       </a>
                                   </li>
                               </ul>
                               <div class="button-group d-flex justify-content-between align-items-center">
                                   <div class="add-friend-btn">
                                   ${subContent}
                                   </div>
                                   <div class="send-message-btn">
                                       <button type="submit">Send Message</button>
                                   </div>
                               </div>
                           </div>
                       </div>
                   </div>
                `;
                }
            }

            UserRefresh()

            var id = document.getElementById("allUsers");
            if (id != null) {
                id.innerHTML = context;
            }

            var id2 = document.getElementById("onlineUsers");
            /*if (id2 != null) {*/
            id2.innerHTML = d;
            //}
            var yourFriendElement = document.getElementById("yourFriend");

            var liveChatFriends = document.getElementById("liveChatFriends");
            if (liveChatFriends != null) {
                liveChatFriends.innerHTML = liveChatFriend;
            }


            if (yourFriendElement != null) {
                yourFriendElement.innerHTML = friendContent;
            }

            $("#liveChatBody").html("");
        }
    })
}

async function GetAllPosts() {
    $.ajax({
        url: "/Home/GetAllPosts",
        method: "GET",
        success: function (data) {
            var context = "";
            for (var i = 0; i < data.length; i++) {
                context += `
                    <div class="news-feed news-feed-post">
                        <div class="post-header d-flex justify-content-between align-items-center">
                            <div class="image">
                                <a href="my-profile.html"><img src="assets/images/user/${data[i].user.imageUrl}" class="rounded-circle" alt="image"></a>
                            </div>
                            <div class="info ms-3">
                                <span class="name"><a href="my-profile.html">${data[i].user.userName}</a></span>
                                <span class="small-text"><a href="#">${data[i].publishTime}</a></span>
                            </div>
                        </div>

                        <div class="post-body ms-1">
                            <p>${data[i].content}</p>
                        </div>
                    </div>
                `;
            }

            var id = document.getElementById("allPosts");
            id.innerHTML = context;
        }
    })
}

//GetAllUsers();
GetAllPosts();
GetMyRequests();