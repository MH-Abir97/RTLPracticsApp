
var app = angular.module('myStudent', []);
app.controller("myStudentController", function ($scope,$http) {

    Clear();
    function Clear() {
        $scope.StudentList = [];
       // $scope.add_student = {}
        ClearStudent();

        $scope.currentPage = 1;
        $scope.PerPage = 10;
        $scope.total_count = 0;

        GetSupplierPaged();

        $scope.deptList = [];

    }

    function GetSupplierPaged() {
        $http({
            url: '/Students/GetAllData',
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            $scope.deptList = response.data;
           
        });
    }

    function ClearStudent() {
        $scope.add_student = new Object();
        $scope.btnStudent = "Add";
        $scope.btnStudentShow = false;
        $scope.studentIndex = '';
    }

    $scope.addColumn = function () {
        if ($scope.btnStudent == "Add") {
            if ($scope.add_student == '' || $scope.add_student==null) {
            }
        }
        $scope.StudentList.push($scope.add_student);
        ClearStudent();
    }
    $scope.removeBtn = function () {
        $scope.StudentList.splice($scope.add_student, 1);
        ClearStudent();
    }

    $scope.SelItemEdit = function (anItem) {
        $scope.add_student = anItem;
    }

    $scope.selStudentColumn = function (studentObj, index) {
        $scope.add_student = studentObj;
        $scope.btnStudent = "Change";
        $scope.btnStudentShow = true;
        $scope.studentIndex = index;
    }



    $scope.SaveBtn = function () {
        var prams = JSON.stringify({ studentList: $scope.StudentList })
            $http({
                url: "/Students/DataSavedList",
                method: "POST",
                data: prams,
            }).then(function (data) {
                ClearStudent();
                console.log(data);
            });
        }
      
    

});