
var app = angular.module('myApp', []);
app.controller('myControl', function ($scope,$http) {

    Clear();
    function Clear() {
       // $scope.add_Student = {};
       // $scope.add_Dept = {};
        $scope.StudentList = [];
        $scope.departList = [];
        $scope.orderList = [];
        $scope.ddlDepartment = null;
        $scope.departmentListObject = [];

        StudentClear();
        DepartmentClear();
        OrderClear();
        GetDepartmentList();
    }

    function GetDepartmentList() {
        $http({
            url: "/Test/GetAllDepartment",
            method: "GET",
        }).then(function (data) {
            $scope.departmentListObject = data;
        });
    }

    function OrderClear() {
        $scope.add_order = new Object();
        $scope.StudentBtn = "Add";
        $scope.orderIndex = '';
    }





    function DepartmentClear() {
        $scope.add_Dept = new Object();
        $scope.deptIndex = '';
        $scope.StudentBtn = "Add";
    }

    function StudentClear() {
    
        $scope.StudentBtn = "Add";
        $scope.add_Student = new Object();
     
        $scope.studentIndex = '';
    }
    $scope.selDepartment = function (item,index) {
        $scope.add_Dept = item;
        $scope.deptIndex = index;
        $scope.deptBtn = "Change";
    }

    $scope.selStudent = function (item,index) {
        $scope.add_Student = item;
        $scope.studentIndex = index;
        $scope.StudentBtn = "Change";

    }

    $scope.addStudent = function () {
        if ($scope.StudentBtn == "Add") {
            if ($scope.add_Student == '' || $scope.add_Student == null ) {
              
            }
            $scope.StudentList.push($scope.add_Student);
            StudentClear();
        }
        if ($scope.add_Dept == '' || $scope.add_Dept != null) {
            $scope.departList.push($scope.add_Dept);

            DepartmentClear();
        }
        if ($scope.add_order == '' || $scope.add_order != null) {
            $scope.orderList.push($scope.add_order);

            OrderClear();
        }
    
   
    }

    $scope.saveBtn = function () {
        var prams = JSON.stringify({ studentList: $scope.StudentList, DeptList: $scope.departList, orderListItem: $scope.orderList });
        $http({
            url: "/Test/DeptAndStudentSave",
            method: "POST",
            data: prams,
        }).then(function (data) {
            console.log(data);
        });
    }



});