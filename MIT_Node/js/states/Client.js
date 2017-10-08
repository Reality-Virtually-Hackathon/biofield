function Client(game) {
	this.game = game;
	this.socket = null;
};
Client.prototype = {
    create: function(){
        this.socket = io.connect();
        var game = this.game;
        var socket = this.socket;
        this.socket.on('WEB_UPDATE_BACTERIA', function(data){
            if(data.id >= game.bacterias.length)
            {
                game.createBacteria(data.x, data.y);
            }
            else
            {
                game.bacterias[data.id].x = data.x;
                game.bacterias[data.id].y = data.y;
            }
        });

        this.socket.on('WEB_UPDATE_LYMPHOCITE', function(data){
            if(data.id >= game.lymphocites.length)
            {
                game.createLymphocite(data.x, data.y);
            }
            else
            {
                game.lymphocites[data.id].x = data.x;
                game.lymphocites[data.id].y = data.y;
            }
        });
        this.socket.on('WEB_UPDATE_BACTERIAFOOD', function(data){
            console.log(data.id  + " : " + game.bacteriaFoods.length)
            if(data.id >= game.bacteriaFoods.length)
            {
                game.createBacteriaFood(data.x, data.y);
            }
            else
            {
                game.bacteriaFoods[data.id].x = data.x;
                game.bacteriaFoods[data.id].y = data.y;
            }
        });
        this.socket.on('WEB_UPDATE_ANTIBODY', function(data){
            if(data.id >= game.antibodies.length)
            {
                game.createAntibody(data.x, data.y);
            }
            else
            {
                game.antibodies[data.id].x = data.x;
                game.antibodies[data.id].y = data.y;
            }
        });
    },

    update: function(){

    }
}