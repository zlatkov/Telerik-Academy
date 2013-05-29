(function () {
    var db = {
        folders: [{id: 1, folderName: "New Folder", children: []}, 
            {id: 2, folderName: "New Folder(1)", children: []},
            {id: 3, folderName: "New Folder(2)", children: []}]
    };

    TreeView = function (param) {
        this.treeViewContainer = param.treeViewContainer;
        this.txtNewFolderName = param.txtNewFolderName;
        this.btnAddFolder = param.btnAddFolder;
        this.tempFolder = param.tempFolder;

        if (!localStorage.getObject('myFolders')) {
            localStorage.setObject('myFolders', []);
        }
    }

    TreeView.prototype = {
        init: function () {
            this.initDB();
            this.initEvents();
        },
        initDB: function () {
            var i;
            var foldersCount = db.folders.length;
            for (i = 0; i < foldersCount; i++) {
                this.treeViewContainer.innerHTML += "<li>" + db.folders[i].folderName + "</li>";
            }
            this.loadMyFolders();
        },
        loadMyFolders: function() {
            var i;
            var foldersCount = localStorage.getObject('myFolders').length;
            for (i = 0; i < foldersCount; i++) {
                this.treeViewContainer.innerHTML += "<li>" + localStorage.getObject('myFolders')[i].folderName + "</li>";
            }
        },
        initEvents: function () {
            var that = this;

            this.btnAddFolder.addEventListener("click", function (evt) {

                evt.preventDefault();

                var folderName = that.txtNewFolderName.value
                that.tempFolder.innerHTML = folderName;
                that.tempFolder.style.visibility = "visible";

                //evt.preventDefault();
                //var folderName = that.txtNewFolderName.value;
                //that.treeViewContainer.innerHTML += "<li>" + folderName + "</li>";

                //var currentFolders = localStorage.getObject('myFolders');
                //currentFolders.push({id: currentFolders.length + 1, "folderName": folderName, children: []});
                //localStorage.setObject('myFolders', currentFolders);

            }, false);

            this.tempFolder.addEventListener('dragstart', function (evt) {
                //console.log(evt);
            }, false);

            this.treeViewContainer.addDelegateListener('dragover', 'li', function (evt) {
                //  console.log(this);
                evt.preventDefault();
            });
            this.treeViewContainer.addDelegateListener('drop', 'li', function (evt) {
                var folderName = that.tempFolder.innerHTML;
                var tmpFolder = document.createElement('li');
                tmpFolder.innerHTML = folderName;
                if (this.nextSibling) {
                    this.parentNode.insertBefore(tmpFolder, this.nextSibling);
                }
                else {
                    this.parentNode.appendChild(tmpFolder);
                }
                that.tempFolder.innerHTML = "";
                that.tempFolder.style.visibility = 'hidden';
            });
        },
    };
})();