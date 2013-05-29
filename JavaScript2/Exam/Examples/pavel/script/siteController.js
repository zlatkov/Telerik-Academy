(function () {
    
    var SiteController = function (param) {
        //this.param = param;
        this.treeViewContainer = document.getElementById(param.treeViewContainer);
        this.btnAddFolder = document.getElementById(param.btnAddFolder);
        this.txtNewFolderName = document.getElementById(param.txtNewFolderName);
        this.tempFolder = document.getElementById(param.tempFolder);
    }
    
    SiteController.prototype = {
        init: function () {
            this.initTreeView();

        },
        initTreeView: function () {
            this.treeView = new TreeView({
                treeViewContainer: this.treeViewContainer,
                txtNewFolderName: this.txtNewFolderName,
                btnAddFolder: this.btnAddFolder,
                tempFolder: this.tempFolder
            });
            this.treeView.init();
        }

    };

    //document.querySelector("body").onload = function () {
    //    var siteController = new SiteController({
    //        treeViewContainer: "treeViewContainer"
    //    });
    //    siteController.init();
    //}
    window.addEventListener('load', function () {
        var siteController = new SiteController({
            treeViewContainer: "treeViewContainer",
            btnAddFolder: "btnAddFolder",
            txtNewFolderName: "txtNewFolderName",
            tempFolder: "tempFolder"
        });
        siteController.init();
    }, false);
})();