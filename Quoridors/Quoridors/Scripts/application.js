//var handleBarSource = $("#entry-template").html();
//var template = Handlebars.compile(handleBarSource);

//var html = template(player);


var processNewGameData = function(data) {
    $.each(data, function(index, player) {
        var playerId = player.PlayerNumber;
        $("#player" + playerId + "Id").html(player.PlayerName);
    });
}

var redrawBoard = function(data) {
    $.each(data.ListOfPlayerPositions, function(index, player) {
        var playerId = player.playerId;
        var gameId = player.gameId;
        var xPos = player.xPos;
        var yPos = player.yPos;

        //$(".gameBoard  tr:nth-child(" + yPos + ") > td:nth-child(" + xPos + ")").children().addClass("#player" + playerId + "Id");
        $(".gameBoard  [data-ypoz='" + yPos + "'][data-xpoz='" + xPos + "']").addClass("#player" + playerId + "Id");
    });
}

//STUB
//var redrawWalls = function(data) {
//    $.each(data.ListOfBricks, function(index, wall) {
//        var xPos = wall.xPos;
//        var yPos = wall.yPos;
//        var brickDirection = wall.topOrLeft;

//        $(".gameBoard").addClass("#wall");
//    });
//}
var player = "player1";

$(document).ready(function() {

    newGame();
    setup();

    //$("#logo").spin().animate({ height: "20px" }, 500);
    
    $(".gameBoard").on('click', 'td', function () {

        $(".gameBoard td").removeClass(player);

        if (player === "player1") {
            player = "player2";
        } else {
            player = "player1";
        }

        $(this).addClass("player2");

        var move = {
            playerId: 1,
            gameId: 1,
            xPos: $(this).data("xPoz"),
            yPoz: $(this).data("yPoz")
        };

        $.ajax({
            type: "POST",
            url: "/Game/MovePlayer",
            data: move
        })
        .done(redrawBoard);
    });
});

function newGame() {
    var newGamePromise = $.ajax("/Game/NewGame");
    newGamePromise.done(processNewGameData);
}

function setup() {
    for (var horizontal = 0; horizontal < 9; horizontal++) {
        var row = $("<tr>");
        for (var vertical = 0; vertical < 9; vertical++) {
            row.append($("<td data-xPoz=" + vertical + " " + "data-yPoz=" + horizontal + "></td>"));
        }
        $(".gameBoard").append(row);
    }
};


