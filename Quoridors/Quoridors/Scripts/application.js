$(document).ready(function() {
    $("#error").on('click', function() {
        $.ajax({
            type: "GET",
            url: "/Game/ThrowError"
        });
    });

    setup();

    var game = new Game();
    game.newGame();
    console.log("newed up game:", game);

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
            //if (game.currentPlayer === "player1") {
            //    game.currentPlayer = "player2";
            //} else {
            //    game.currentPlayer = "player1";
            //}

            var player;
            if (game.turn % 2 == 1) {
                game.currentPlayer = game.player1;
                player = "player1";
                game.turn += 1; //temp turn increment
                $("#player-turn").removeClass(player);
                $("#player-turn").addClass("player2");
            } else {
                game.currentPlayer = game.player2;
                player = "player2";
                game.turn += 1; //temp turn increment
                $("#player-turn").removeClass(player);
                $("#player-turn").addClass("player1");
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


    $(".gameBoard").on('click', 'td', function () {
        var player;

        //if (game.currentPlayer.xPos - $(this)) {
            //currently working on this.
        //};

        if (game.turn % 2 == 1) {
            game.currentPlayer = game.player1;
            player = "player1";
            game.turn += 1; //temp turn increment
            $("#player-turn").removeClass(player);
            $("#player-turn").addClass("player2");
        } else {
            game.currentPlayer = game.player2;
            player = "player2";
            game.turn += 1; //temp turn increment
            $("#player-turn").removeClass(player);
            $("#player-turn").addClass("player1");
        }

        $(".gameBoard td").removeClass(player);
        $(this).addClass(player);

        $("#player-turn").html(player);

        var move = {
            PlayerId: game.currentPlayer.id,
            GameId: game.ID,
            XPos: $(this).attr("data-yPoz"),
            YPos: $(this).attr("data-xPoz"),
    };

        $.ajax({
            type: "POST",
            url: "/Game/MovePlayer",
            data: move,
            success: game.redrawBoard,
            error: function() {
                console.log("you fail");
            }
        });
    });
});



function setup() {
    for (var horizontal = 0; horizontal < 9; horizontal++) {
        var row = $("<tr>");
        for (var vertical = 0; vertical < 9; vertical++) {
            row.append($("<td data-bind='click: registerClick(" + vertical + ", " + horizontal + "), css: playerCss(" + vertical + ", " + horizontal + ")' data-xPoz=" + vertical + " " + "data-yPoz=" + horizontal + "></td>"));
        }
        $(".gameBoard").append(row);
    }
}

var Game = function () {
    this.ID = "";
    this.player1 = new Player();
    this.player2 = new Player();
    this.currentPlayer;
    this.turn;
    self = this;
}
Game.prototype = {
     newGame: function() {
            $.ajax({
            type: "GET",
            url: "/Game/NewGame",
            success: this.processNewGameData,
            error: function() {
            console.log("NewGame not made");
            }
        });
    },

    processNewGameData: function(data) {
        console.log("inside processNewGameData");
        console.log("process gamedata:", data);
        self.ID = data.GameId;
        self.turn = data.Turn;
        self.player1 = {
            id: data.ListOfPlayerPositions[0].PlayerId,
            xPos: data.ListOfPlayerPositions[0].XPos,
            yPos: data.ListOfPlayerPositions[0].YPos,
        };
        console.log("process game data: player1", self.player1);
        self.player2 = {
            id: data.ListOfPlayerPositions[1].PlayerId,
            xPos: data.ListOfPlayerPositions[1].XPos,
            yPos: data.ListOfPlayerPositions[1].YPos,
        };
        console.log("process game data: player2", self.player2);

        self.currentPlayer = self.player1;
        self.redrawBoard(data);
    },

    redrawBoard: function (data) {
        console.log("inside redrawBoard");
        console.log(data);

        $.each(data.ListOfPlayerPositions, function(index, player) {    //please note: x and y are inverted between front end and backend!!
                if (self.player1.id === player.PlayerId) {
                    $("td[data-ypoz='" + player.XPos + "'][data-xpoz='" + player.YPos + "']").addClass("player1");
                    console.log("player1 xpos:", player.XPos);
                    console.log("player1 xpos:", player.YPos);
                    console.log("player1 redrawn");
                }
                if (self.player2.id === player.PlayerId) {
                    $("td[data-ypoz='" + player.XPos + "'][data-xpoz='" + player.YPos + "']").addClass("player2");
                    console.log("player2 xpos:", player.XPos);
                    console.log("player2 ypos:", player.YPos);
                    console.log("player2 redrawn");
                }
        });
    }
}

var Player = function() {
    
};


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

