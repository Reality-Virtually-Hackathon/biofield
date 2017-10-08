GameCtrl.RoleSelect = function(game)
{
    this.playButton = null;
    // LG
    this.bacteriaButton = null;
    this.lymphButton = null;
};

GameCtrl.RoleSelect.prototype = {

        create: function () {
                this.background = this.add.sprite(0, 0, 'background');
                // Select Entity Text
                this.selectEntity = this.add.button(this.game.width- 729, this.game.height - 752, 'select_entity');
                // Buttons
                this.neutroButton = this.add.button(this.game.width- 1010, this.game.height - 700, 'neutroButton', this.selectNeutro, this, 'buttonOver', 'buttonOut', 'buttonOver');
                this.bacteriaButton = this.add.button(this.game.width- 520, this.game.height - 700, 'bacteriaButton', this.selectBacteria, this, 'buttonOver', 'buttonOut', 'buttonOver');
        },

        update: function () {

                //        Do some nice funky main menu effect?

        },

        selectNeutro: function (pointer) {
            this.deactivateRoleDescriptions();
            this.loadNeutroOverview();
        },

        selectBacteria: function (pointer){
            this.deactivateRoleDescriptions();
            this.loadBacteriaOverview();
        },

        deactivateRoleDescriptions: function()
        {
            this.bacteriaButton.visible = false;
            this.neutroButton.visible = false;
            this.selectEntity.visible = false;
        },

        loadNeutroOverview: function()
        {
            this.neutroOverview = this.add.button(this.game.width- 880, this.game.height - 680, 'neutroOverview');
            this.howToPlay = this.add.button(this.game.width- 709, this.game.height - 752, 'how_to_play');
            this.back = this.add.button(this.game.width- 950, this.game.height - 170, 'back', this.selectBack, this, 'buttonOver', 'buttonOut', 'buttonOver');
            this.select = this.add.button(this.game.width- 310, this.game.height - 170, 'select', this.selectSelectNeutro, this, 'buttonOver', 'buttonOut', 'buttonOver');
        },

        loadBacteriaOverview: function()
        {
            this.bacteriaOverview = this.add.button(this.game.width- 880, this.game.height - 680, 'bacteriaOverview');
            this.howToPlay = this.add.button(this.game.width- 709, this.game.height - 752, 'how_to_play');
            this.back = this.add.button(this.game.width- 950, this.game.height - 170, 'back', this.selectBack, this, 'buttonOver', 'buttonOut', 'buttonOver');
            this.select = this.add.button(this.game.width- 310, this.game.height - 170, 'select', this.selectSelectBacteria, this, 'buttonOver', 'buttonOut', 'buttonOver');
        },

        selectBack: function()
        {
            this.game.state.start('MainMenu');
        },

        selectSelectNeutro: function()
        {
            this.game.selection = 'neutro';
            this.game.state.start('Game');
        },

        selectSelectBacteria: function()
        {
            this.game.selection = 'bacteria';
            this.game.state.start('Game');
        }
    }
