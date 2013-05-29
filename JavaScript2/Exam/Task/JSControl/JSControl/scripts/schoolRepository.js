var schoolRepository = (function () {
    (function () {
        if (!Storage.prototype.setObject) {
            Storage.prototype.setObject = function (key, obj) {
                this.setItem(key, JSON.stringify(obj));
            };
        }
    })();

    (function () {
        if (!Storage.prototype.getObject) {
            Storage.prototype.getObject = function (key) {
                return JSON.parse(this.getItem(key));
            };
        }
    })();

    function Student(firstName, lastName, grade, mark) {
        this.toJSON = function () {
            return {
                firstName: firstName,
                lastName: lastName,
                grade: grade,
                mark: mark
            };
        };
    }

    function Course(title, startDate, totalStudents, studentsList) {
        this.toJSON = function () {
            return {
                title: title,
                startDate: startDate,
                totalStudents: totalStudents,
                studentsList: studentsList
            };
        };
    }

    function School(name, location, numberOfCourses, speciality, coursesList) {
        this.toJSON = function () {
            return {
                name: name,
                location: location,
                numberOfCourses: numberOfCourses,
                speciality: speciality,
                coursesList: coursesList
            };
        };
    }

    return {
        save: function (key, schoolsData) {
            localStorage.setObject(key, schoolsData);
        },
        load: function (key) {
            return localStorage.getObject(key);
        },
        createNewStudent: function (firstName, lastName, grade, mark) {
            return new Student(firstName, lastName, grade, mark);
        },
        createNewCourse: function (title, startDate, totalStudents, studentsList) {
            return new Course(title, startDate, totalStudents, studentsList);
        },
        createNewSchool: function (name, location, numberOfCourses, speciality, couresesList) {
            return new School(name, location, numberOfCourses, speciality, couresesList);
        }
    };
})();
