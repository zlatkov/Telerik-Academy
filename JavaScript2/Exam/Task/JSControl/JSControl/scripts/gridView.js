var controls = (function () {
    function GridView(gridViewHolder) { 
        var data = []; 
        var gridView = document.createElement("table");
        var tableHeadItems = [];
        var self = this;

        function getTableHeadIndex(text) {
            var headItemsLen = tableHeadItems.length;
            for (var i = 0; i < headItemsLen; i += 1) {
                if (tableHeadItems[i] === text) {
                    return i;
                }
            }
            return -1;
        }

       

        gridViewHolder.addEventListener("click", function (ev) {
            if (!ev) {
                ev = window.event;
            }
            ev.stopPropagation();
            ev.preventDefault();

            var clickedItem = ev.target;
            if (!(clickedItem instanceof HTMLTableCellElement)) {
                return;
            }

                var divSinblingExists = false;
                var divElement;
                while (clickedItem) {
                    if (clickedItem instanceof HTMLDivElement) {
                        divElement = clickedItem;
                        divSinblingExists = true;
                    }
                    clickedItem = clickedItem.nextElementSibling;
                }

                if (divSinblingExists) {
                    if (divElement.style.display === "none") {
                        divElement.style.display = "inline";
                    }
                    else {
                        divElement.style.display = "none";
                    }
                }
            

        }, false);

        this.addHeader = function () {
            tableHeadItems = [];
            for (var i = 0; i < arguments.length; ++i) {
                tableHeadItems.push(arguments[i]); 
            }
            var newHeader = new Header(arguments);
            data.push(newHeader);
            return newHeader;
        };

        this.addRow = function () {
            var newRow = new Row(arguments);
            data.push(newRow);
            return newRow;
        };

        this.render = function () {
            while (gridViewHolder.firstChild) {
                gridViewHolder.removeChild(gridViewHolder.firstChild);
            }

            while (gridView.firstChild) {
                gridView.removeChild(gridView.firstChild);
            }

            var dataLength = data.length;
            for (var i = 0; i < dataLength; i += 1) {
                var domItem = data[i];
                gridView.appendChild(domItem.render());
            }

            gridViewHolder.appendChild(gridView);
            return gridView;
        };

        this.getGridViewData = function () {
            var dataLength = data.length; 
            var dataGridViewSerialized = []; 
            for (var i = 0; i < dataLength; i += 1) {
                if (!data[i].isTableHead) {
                    dataGridViewSerialized.push(data[i].serialize(tableHeadItems));
                }
            }

            return dataGridViewSerialized;
        };

        this.load = function (data) {
            var dataLength = data.length;
            var isSchool = false;
            var isCourse = false;
            var isStudent = false;
            if (data[0].Name) {
                isSchool = true;
                this.addHeader("Name", "Location", "Total Students", "Speciality");
            }
            else if (data[0].Title) {
                isCourse = true;
                this.addHeader("Title", "Start Date", "Total Students");
            }
            else {
                isStudent = true;
                this.addHeader("First Name", "Last Name", "Grade", "Marks");
            }

            for (var i = 0; i < dataLength; i += 1) {
                var subGridViewRow;
                if (isSchool) {
                    subGridViewRow = this.addRow(data[i]["Name"], data[i]["Locationn"], data[i]["Total Students"], data[i]["Speciality"]);
                }
                else if (isCourse) {
                    subGridViewRow = this.addRow(data[i]["Title"], data[i]["Start Date"], data[i]["Total Students"]);
                }
                else {
                    subGridViewRow = this.addRow(data[i]["First Name"], data[i]["Last Name"], data[i]["Grade"], data[i]["Mark"]);
                }

                if (data[i].list) {
                    var subGridView = subGridViewRow.getNestedGridView();
                    subGridView.load(data[i].list);
                }
            }
        };
    }

    function GridViewSelector(selector) {
        var gridViewHolder = document.querySelector(selector);
        return new GridView(gridViewHolder);
    }

    function Row(itemsList, shouldBeHeader) {
        var nestedGridView;
        var nestedGridViewHolder;
        var hasNestedGridView = false;

        this.items = itemsList;
        this.isTableHead = false;
        this.getNestedGridView = function () {
            nestedGridViewHolder = document.createElement("div");
            nestedGridView = new GridView(nestedGridViewHolder);
            hasNestedGridView = true;

            return nestedGridView;
        };

        this.render = function () {
            var newRow = document.createElement("tr");

            var cellType;
            if (shouldBeHeader) {
                this.isTableHead = true;
                cellType = "th";
            }
            else {
                cellType = "td";
            }

            var numberOfCells = itemsList.length;
            for (var i = 0; i < numberOfCells; i += 1) {
                var newCell = document.createElement(cellType);

                if (cellType === "th") {
                    newCell.className = "head";
                }

                newCell.innerHTML = itemsList[i];
                newRow.appendChild(newCell);
            }

            if (hasNestedGridView) {
                nestedGridViewHolder.appendChild(nestedGridView.render());
                nestedGridViewHolder.style.display = "none";
                newRow.appendChild(nestedGridViewHolder);
            }

            if (this.isTableHead) {
                var theadElement = document.createElement("thead");
                theadElement.appendChild(newRow);
                return theadElement;
            }

            return newRow;
        };

        this.serialize = function (headers) {
            var rowSerialized = {};
            var itemsCount = headers.length;
            for (var i = 0; i < itemsCount; i += 1) {
                rowSerialized[headers[i]] = itemsList[i];
            }

            if (hasNestedGridView) {
                rowSerialized.list = nestedGridView.getGridViewData();
            }
            return rowSerialized;
        };
    }

    function Header(itemsList) {
        this.items = itemsList;
        this.render = function () {
            var newHeader = new Row(itemsList, true);
            return newHeader.render();
        };

        this.serialize = function (tableHeadData) {
            var newRow = new Row(itemsList, true);
            return newRow.serialize(tableHeadData);
        };
        this.isTableHead = true;
    }

    return {
        getGridView: function (selector) {
            return new GridViewSelector(selector);
        },
        buildGridView: function (selector, data) {
            var gridView = new GridViewSelector(selector);
            gridView.load(data);
            return gridView;
        }
    };
})(); 