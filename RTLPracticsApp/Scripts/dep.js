var app = angular.module('MyApp', ['angularjs-dropdown-multiselect']);
app.controller('multiselectdropdown', function ($scope, $http) {
    //define object
    $scope.CategoriesSelected = [];
    $scope.Categories = [];
    $scope.SubmittedCategories = [];
    $scope.dep = {};
    $scope.dropdownSetting = {
        scrollable: true,
        scrollableHeight: '200px'
    }
    //fetch data from database for show in multiselect dropdown
    $http.get('/DepartmentsTest/GetDataList').then(function (data) {
        angular.forEach(data.data, function (value, index) {
            $scope.Categories.push({ id: value.Id, label: value.Name });
        });
    });
    //post or submit selected items from multiselect dropdown to server

    $scope.SubmitData = function () {
        var categoryIds =[];
        angular.forEach($scope.CategoriesSelected, function (value, index) {
            //categoryIds += categoryIds === '' ? value.id : ',' + value.id;
            categoryIds.push(value.id);
        });

        $http({
            url: '/DepartmentsTest/GetDropdownList?categoryIds=' + categoryIds,
            method: "POST",
            headers: { 'Content-Type': 'application' },

        }).then(function (response) {
            $scope.SubmittedCategories = response.data;

        });
    }
});