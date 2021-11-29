$(document).ready(
    function () {
        //declare a proxy to hub
        var chat = $.connection.chatHub;

        chat.client.broadcastMessage = function (name, message) {
            // Html encode display name and message. 
            var encodedName = $('<div />').text(name).html();
            var encodedMessage = $('<div />').text(message).html();
            // Add the message to the page. 
            $('#discussion').append('<li><strong>' + encodedName
                + '</strong>:&nbsp;&nbsp;' + encodedMessage + '</li>');
        };

        $('#message').focus();

        $.connection.hub.start()
            .done(function () {
                $('#sendmessage').click(function(){
                    chat.server.send($('#displayname').val(), $('#message').val(), $('#displayroom').val());
                    $('#message').val('').focus();
                });
                chat.server.startChating($('#displayname').val(), $('#displayroom').val());
                //$('#show-chat').click(function () {
                //    var chatBodyNode = $('.js-chat-body');
                //    if (chatBodyNode.hasClass('hidden'))
                //    {
                //        chatBodyNode.removeClass('hidden');
                //    }
                //    else {
                //        chatBodyNode.addClass('hidden');
                //    }
                //}
                /*)*/;
            });

    });