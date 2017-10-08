GameCtrl.MainMenu = function (game) {

        //this.music = null;
        this.playButton = null;
        this.title = null;
        // Added buttons
        this.bacteriaButton = null;
        this.lymphButton = null;

};

GameCtrl.MainMenu.prototype = {

        create: function () {

                //        We've already preloaded our assets, so let's kick right into the Main Menu itself.
                //        Here all we're doing is playing some music and adding a picture and button
                //        Naturally I expect you to do something significantly better :)

                // this.music = this.add.audio('titleMusic');
                // this.music.play();

                this.background = this.add.sprite(0, 0, 'background');
                this.title = this.add.button(this.game.width- 750, this.game.height - 475, 'title', this.startGame, this, 'buttonOver', 'buttonOut', 'buttonOver');
                this.playButton = this.add.button(this.game.width- 660, this.game.height - 300, 'playButton', this.startGame, this, 'buttonOver', 'buttonOut', 'buttonOver');
        },

        update: function () {

                //        Do some nice funky main menu effect here

        },

        startGame: function (pointer) {

                //        Ok, the Play Button has been clicked or touched, so let's stop the music (otherwise it'll carry on playing)
                // this.music.stop();

                this.game.state.start('RoleSelect');

        }

};
