GameCtrl.Game = function (game) {

        //        When a State is added to Phaser it automatically has the following properties set on it, even if they already exist:

    this.game;                //        a reference to the currently running game
    this.add;                //        used to add sprites, text, groups, etc
    this.camera;        //        a reference to the game camera
    this.cache;                //        the game cache
    this.input;                //        the global input manager (you can access this.input.keyboard, this.input.mouse, as well from it)
    this.load;                //        for preloading assets
    this.math;                //        lots of useful common math operations
    this.sound;                //        the sound manager - add a sound, play one, set-up markers, etc
    this.stage;                //        the game stage
    this.time;                //        the clock
    this.tweens;        //        the tween manager
    this.world;                //        the game world
    this.particles;        //        the particle manager
    this.physics;        //        the physics manager
    this.rnd;                //        the repeatable random number generator

    //        You can use any of these from any function within this State.
    //        But do consider them as being 'reserved words', i.e. don't create a property for your own game called "world" or you'll over-write the world reference.

};

GameCtrl.Game.prototype = {

        create: function () {
                //        Honestly, just about anything could go here. It's YOUR game after all. Eat your heart out!
                this.background = this.add.sprite(0, 0, 'background');
                
                this.bacterias = [];
                this.lymphocites = [];
                this.antibodies = [];
                this.bacteriaFoods = [];

                this.client = new Client(this);
                this.client.create();

                upKey = this.game.input.keyboard.addKey(Phaser.Keyboard.UP);
                downKey = this.game.input.keyboard.addKey(Phaser.Keyboard.DOWN);
                leftKey = this.game.input.keyboard.addKey(Phaser.Keyboard.LEFT);
                rightKey = this.game.input.keyboard.addKey(Phaser.Keyboard.RIGHT);
        },

        update: function () {
            if (upKey.isDown)
            {
                this.client.socket.emit('MOVE_BACTERIA', 'up');
            }
            else if (downKey.isDown)
            {
                this.client.socket.emit('MOVE_BACTERIA', 'down');
            }
            if (leftKey.isDown)
            {
                this.client.socket.emit('MOVE_BACTERIA', 'left');
            }
            else if (rightKey.isDown)
            {
                this.client.socket.emit('MOVE_BACTERIA', 'right');
            }
        
        },
        quitGame: function (pointer) {

                //        Here you should destroy anything you no longer need.
                //        Stop music, delete sprites, purge caches, free resources, all that good stuff.

                //        Then let's go back to the main menu.
                this.game.state.start('MainMenu');

        },
        createBacteria: function(x, y)
        {
            this.bacteria = this.add.sprite(x, y, 'bacteriaSprite')

            this.bacteria.scale.x /= 2;
            this.bacteria.scale.y /= 2;
            this.bacteria.x = x;
            this.bacteria.y = y;
            this.bacterias.push(this.bacteria);
        },
        createLymphocite: function(x, y)
        {
            this.lymphocite = this.add.sprite(x, y, 'lymphoSprite')

            this.lymphocite.scale.x /= 2;
            this.lymphocite.scale.y /= 2;
            this.lymphocite.x = x;
            this.lymphocite.y = y;
            this.lymphocites.push(this.lymphocite);
        },
        createBacteriaFood: function(x, y)
        {
            this.bacteriaFood = this.add.sprite(x, y, 'bacteriaFoodSprite')

            this.bacteriaFood.scale.x /= 2;
            this.bacteriaFood.scale.y /= 2;
            this.bacteriaFood.x = x;
            this.bacteriaFood.y = y;
            this.bacteriaFoods.push(this.bacteriaFood);
        },
        createAntibody: function(x, y)
        {
            this.antibody = this.add.sprite(x, y, 'antibodySprite')

            this.antibody.scale.x /= 2;
            this.antibody.scale.y /= 2;
            this.antibody.x = x;
            this.antibody.y = y;
            this.antibodies.push(this.bacteria);
        },
};