var app = angular.module('MyApp', []);

app.controller('MyControl', function ($scope, $http) {
    Clear();
    function Clear() {
        $scope.name = 'Department Name';
        $scope.departmentList = [];
       // $scope.addDept = {};


        $scope.ddlOrder = null;
        $scope.ddlItem = null;
        $scope.orderListItem = [];



        ClearDepartment();


        $scope.deptListItemTable = [];
        GetAllList();
       // getAllOrderList();
    }


    $scope.departModal = function () {
        $('#deptmodal').modal('show');
    }
    //function getAllOrderList() {
    //    $http({
    //        url: "/DTest/GetAllOrder",
    //        method: "GET",
    //        headers: { 'Content-Type': 'application/json' }
    //    }).then(function (data) {
    //        $scope.orderListItem = data;
    //        console.log(data);
    //    });
    //}

    function GetAllList() {
        $http({
            url: "/DTest/GetAllDepartmentList",
            method: "Get",
            headers: {'Content-Type':'application/json'}
        }).then(function (response) {

            $scope.deptListItemTable = response.data;
            //console.log(response);
        });
    }



    function ClearDepartment() {
        $scope.addDept = new Object();
        $scope.btnDepatment = "Add";
        $scope.btnDepartmentShowe = false;
        $scope.departmentIndex = '';
    }

    $scope.AddColum = function () {
        if ($scope.btnDepatment == "Add") {
            if ($scope.addDept == "" || $scope.addDept ==null) {

            }
        }
        $scope.departmentList.push($scope.addDept);
        ClearDepartment();
    }

    $scope.selDepartment = function (deptPolicy, index) {
        $scope.addDept = deptPolicy;
        $scope.btnDepatment = "Change";
        $scope.btnDepartmentShowe = true;
        $scope.departmentIndex = index;
    }

    $scope.remove = function () {
        $scope.departmentList.splice($scope.addDept, 1);
        ClearDepartment();
    }
    $scope.addEdit = function (dept) {
        $scope.addDept = dept;
    }

    $scope.btnSave = function () {

        var prams = JSON.stringify({ deptList: $scope.departmentList});
        $http({
            url: "/DTest/saveDepartment",
            method: "POST",
            data: prams,
            headers: { 'Content-Type': 'application/json' }
        }).then(function (data) {
            Clear();
            console.log('Dept List Save',data);
        });
    }





});