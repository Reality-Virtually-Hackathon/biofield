GameCtrl.RoleSelect = function(game)
{
    this.music = null;
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

        },
        
        loadBacteriaOverview: function()
        {

        }


    }
