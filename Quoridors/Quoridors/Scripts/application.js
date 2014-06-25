var player = "player1";

var ViewModel = function () {
    this.playerTurn = ko.observable(1),

    this.updatePlayerCss = function() {
        return "player1";
    }

    this.registerClick = function (xPoz, yPoz) {
        console.log("clicked me");
        $(".gameBoard td").removeClass(player);
        console.log(xPoz, yPoz);
        $(".gameBoard tr:nth-child(" + (yPoz+1) + ") > td:nth-child(" + (xPoz+1) + ")").addClass(player);

    }
}

$(document).ready(function() {
    setup();
    ko.applyBindings(new ViewModel());
    //$("#logo").spin().animate({ height: "20px" }, 500);
    $(".draggable").draggable({ helper: "clone" });

    $(".gameBoard td").droppable({
        over: function (event, ui) {
            if (ui.helper.context.className.contains("horizontal")) {
                $(this).addClass("hover-wall-top");
                $(this).next().addClass("hover-wall-top");
            } else {
                $(this).addClass("hover-wall-left");
                var xPos = $(this).attr("data-xpoz");
                $(this).parent().next().children().eq(xPos).addClass("hover-wall-left");
            }
        },

        out: function (event, ui) {
            if (ui.helper.context.className.contains("horizontal")) {
                $(this).removeClass("hover-wall-top");
                $(this).next().removeClass("hover-wall-top");
            } else {
                $(this).removeClass("hover-wall-left");
                var xPos = $(this).attr("data-xpoz");
                $(this).parent().next().children().eq(xPos).removeClass("hover-wall-left");
            }
        },

        // TODO reply to server with walldrop
        drop: function (event, ui) {
            if (player === "player1") {
                player = "player2";
            } else {
                player = "player1";
            }
            $("#player-turn").html(player);
            if (ui.helper.context.className.contains("horizontal")) {
                $(this).removeClass("hover-wall-top");
                $(this).next().removeClass("hover-wall-top");
                $(this).addClass("wall-top");
                $(this).next().addClass("wall-top");
            } else {
                $(this).removeClass("hover-wall-left");
                $(this).addClass("wall-left");
                var xPos = $(this).attr("data-xpoz");
                $(this).parent().next().children().eq(xPos).removeClass("hover-wall-left").addClass("wall-left");
            }
        }
    });

    newGame();


    //$(".gameBoard").on('click', 'td', function () {
        

    //    if (player === "player1") {
    //        player = "player2";
    //    } else {
    //        player = "player1";
    //    }

    //    $(".gameBoard td").removeClass(player);
    //    $(this).addClass(player);

    //    $("#player-turn").html(player);

    //    var move = {
    //        playerId: 1,
    //        gameId: 1,
    //        xPos: $(this).data("xPoz"),
    //        yPoz: $(this).data("yPoz")
    //    };

    //    $.ajax({
    //        type: "POST",
    //        url: "/Game/MovePlayer",
    //        data: move
    //    })
    //    .done(redrawBoard);
    //});
});

function newGame() {
    var newGamePromise = $.ajax("/Game/NewGame");
    newGamePromise.done(processNewGameData);
}

function setup() {
    for (var horizontal = 0; horizontal < 9; horizontal++) {
        var row = $("<tr>");
        for (var vertical = 0; vertical < 9; vertical++) {
            row.append($("<td data-bind='click: registerClick("+vertical+", "+horizontal+")' data-xPoz=" + vertical + " " + "data-yPoz=" + horizontal + "></td>"));
        }
        $(".gameBoard").append(row);
    }
}



var processNewGameData = function (data) {
    $.each(data, function (index, player) {
        var playerId = player.PlayerNumber;
        $("#player" + playerId + "Id").html(player.PlayerName);
    });
}

var redrawBoard = function (data) {
    $.each(data.ListOfPlayerPositions, function (index, player) {
        var playerId = player.playerId;
        var gameId = player.gameId;
        var xPos = player.xPos;
        var yPos = player.yPos;

        //$(".gameBoard  tr:nth-child(" + yPos + ") > td:nth-child(" + xPos + ")").children().addClass("#player" + playerId + "Id");
        $(".gameBoard  [data-ypoz='" + yPos + "'][data-xpoz='" + xPos + "']").addClass("#player" + playerId + "Id");
    });
}



//var handleBarSource = $("#entry-template").html();
//var template = Handlebars.compile(handleBarSource);

//var html = template(player);

//STUB
//var redrawWalls = function(data) {
//    $.each(data.ListOfBricks, function(index, wall) {
//        var xPos = wall.xPos;
//        var yPos = wall.yPos;
//        var brickDirection = wall.topOrLeft;

//        $(".gameBoard").addClass("#wall");
//    });
//}

