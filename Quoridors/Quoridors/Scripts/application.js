var player = "player1";

//var ViewModel = function (player) {
//    this.player = player,
//    this.playerTurn = ko.observable(1),
//    this.player1Position = ko.observable(),
//    this.player2Position = ko.observable(),

//    this.playerCss = function (xPoz, yPoz) {
//        if (xPoz === this.player1Position().x && yPoz === this.player1Position().y) {
//            return "player1";
//        }
//        if (xPoz === this.player2Position().x && yPoz === this.player2Position().y) {
//            return "player2";
//        }
//        return "";
//    },

//    this.registerClick = function (xPoz, yPoz) {
//        if (this.player === "player1") {
//            this.player = "player2";
//            this.player2Position({
//                x: xPoz,
//                y: yPoz
//            });

//        } else {
//            this.player1Position({
//                x: xPoz,
//                y: yPoz
//            });
//            this.player = "player1";
//        }
//    }
//}



$(document).ready(function() {

    setup();

    //ko.applyBindings(new ViewModel());
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

    $(".gameBoard").on('click', 'td', function () {


        if (player === "player1") {
            player = "player2";
        } else {
            player = "player1";
        }

        $(".gameBoard td").removeClass(player);
        $(this).addClass(player);

        $("#player-turn").html(player);

        var move = {
            PlayerId: 1,
            GameId: 1,
            XPos: $(this).attr("data-yPoz"),
            YPos: $(this).attr("data-xPoz")
        };

        $.ajax({
            type: "POST",
            url: "/Game/MovePlayer",
            data: move,
            success: redrawBoard,
            error: function() {
                console.log("you fail");
            }
        });
    });
});

function newGame() {
    $.ajax({
        type: "GET",
        url: "/Game/NewGame",
        success: processNewGameData
    });
}

function setup() {
    for (var horizontal = 0; horizontal < 9; horizontal++) {
        var row = $("<tr>");
        for (var vertical = 0; vertical < 9; vertical++) {
            row.append($("<td data-bind='click: registerClick(" + vertical + ", " + horizontal + "), css: playerCss(" + vertical + ", " + horizontal + ")' data-xPoz=" + vertical + " " + "data-yPoz=" + horizontal + "></td>"));
        }
        $(".gameBoard").append(row);
    }
}



var processNewGameData = function (data) {
    var gameId = data.GameId;
    var turn = data.Turn;
    var player1 = {
        id: data.ListOfPlayerPositions[0].PlayerId,
        xPos: data.ListOfPlayerPositions[0].XPos,
        yPos: data.ListOfPlayerPositions[0].YPos,
    }

    var player2 = {
        id: data.ListOfPlayerPositions[1].PlayerId,
        xPos: data.ListOfPlayerPositions[1].XPos,
        yPos: data.ListOfPlayerPositions[1].YPos,
    }

    //$.each(data, function (index, player) {
    //    var playerId = player.PlayerNumber;
    //    $("#player" + playerId + "Id").html(player.PlayerName);
    //});
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

