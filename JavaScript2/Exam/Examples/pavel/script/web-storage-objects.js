(function () {
    var div = document.createElement("div");
    var prefix = ["moz", "webkit", "ms", "o"].filter(function (prefix) {
        return prefix + "MatchesSelector" in div;
    })[0] + "MatchesSelector";

    if (!Storage.prototype.setObject) {
        Storage.prototype.setObject = function setObject(key, obj) {
            var jsonObj = JSON.stringify(obj);
            this.setItem(key, jsonObj);
        };

    }
    if (!Storage.prototype.getObject) {
        Storage.prototype.getObject = function getObject(key) {
            var jsonObj = this.getItem(key);
            var obj = JSON.parse(jsonObj);
            return obj;
        };
    }


    Element.prototype.addDelegateListener = function (type, selector, fn) {

        this.addEventListener(type, function (e) {
            var target = e.target;

            while (target && target !== this && !target[prefix](selector)) {
                target = target.parentNode;
            }

            if (target && target !== this) {
                return fn.call(target, e);
            }

        }, false);
    };
})();
