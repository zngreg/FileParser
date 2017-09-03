(function () {
  'use strict';

  app.controller('homeController', homeController);

  homeController.$inject = ['$scope', '$rootScope', 'filesFactory'];

  function homeController($scope, $rootScope, filesFactory) {
    $scope.title = 'homeController';
    $scope.namesFile = {};
    $scope.addressFile = {};
    $scope.names = [];
    $scope.addresses = [];

    $scope.addNames = function () {
      var f = document.getElementById('fileUpload').files[0],
        r = new FileReader();
      r.onloadend = function (e) {
        $scope.namesFile.name = f.name;
        $scope.namesFile.data = e.target.result;
      };
      r.readAsDataURL(f);
    };

    $scope.addAddresses = function () {
      var f = document.getElementById('fileUpload1').files[0],
        r = new FileReader();
      r.onloadend = function (e) {
        $scope.addressFile.name = f.name;
        $scope.addressFile.data = e.target.result;
      };
      r.readAsDataURL(f);
    };

    $scope.uploadNamesFile = function () {

      filesFactory.uploadNamesFile($scope.namesFile).then(function (response) {
        $scope.names = response.data;

        $rootScope.isProccessing = false;
      }, function (err) {
        $rootScope.isProccessing = false;
        $scope.message = typeof err.error_description !== 'undefined' ? err.error_description : typeof err.data.message !== 'undefined' ? err.data.message : 'Something wrong happened, contact administrator for assistance.';
      });
    };

    $scope.uploadAddressesFile = function () {

      filesFactory.uploadAddressesFile($scope.addressFile).then(function (response) {
        $scope.addresses = response.data;

        $rootScope.isProccessing = false;
      }, function (err) {
        $rootScope.isProccessing = false;
        $scope.message = typeof err.error_description !== 'undefined' ? err.error_description : typeof err.data.message !== 'undefined' ? err.data.message : 'Something wrong happened, contact administrator for assistance.';
      });
    };

    activate();

    function activate() { }
  }
})();
