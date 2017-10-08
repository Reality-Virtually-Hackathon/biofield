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

                this.neutroButton = this.add.button(this.game.width- 1025, this.game.height - 725, 'neutroButton', this.selectNeutro, this, 'buttonOver', 'buttonOut', 'buttonOver');
                this.bacteriaButton = this.add.button(this.game.width- 525, this.game.height - 725, 'bacteriaButton', this.selectBacteria, this, 'buttonOver', 'buttonOut', 'buttonOver');
        },

        update: function () {

                //        Do some nice funky main menu effect here

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
        },

        loadNeutroOverview: function()
        {
            this.neutroOverview = this.add.button(this.game.width- 1100, this.game.height - 850, 'neutroOverview');
            this.back = this.add.button(this.game.width- 800, this.game.height - 200, 'back', this.selectBack, this, 'buttonOver', 'buttonOut', 'buttonOver');
            this.select = this.add.button(this.game.width- 300, this.game.height - 200, 'select', this.selectSelectNeutro, this, 'buttonOver', 'buttonOut', 'buttonOver');
        },
        
        loadBacteriaOverview: function()
        {
            this.bacteriaOverview = this.add.button(this.game.width- 1100, this.game.height - 850, 'bacteriaOverview');
            this.back = this.add.button(this.game.width- 800, this.game.height - 200, 'back', this.selectBack, this, 'buttonOver', 'buttonOut', 'buttonOver');
            this.select = this.add.button(this.game.width- 300, this.game.height - 200, 'select', this.selectSelectBacteria, this, 'buttonOver', 'buttonOut', 'buttonOver');
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
