(function() {
  var app;

  app = angular.module('app', ['ngRoute']);

  app.controller('DemoCtrl', [
    '$scope', 'demoService', function($scope, demoService) {
      var Id;
      $scope.Income1 = 60000;
      $scope.Income2 = 30000;
      $scope.hideRows = false;
      $scope.hideRow = function() {
        return $scope.hideRows = !$scope.hideRows;
      };
      $scope.alerts = "loading";
      demoService.getAlerts().then(function(ret) {
        return $scope.alerts = ret;
      });
      $scope.closeAlert = function(index) {
        return $scope.alerts.splice(index, 1);
      };
      $scope.myalert = Id = 0;
      $scope.type = "";
      $scope.$watch('myalert.Id', function(val) {
        if (val === 1) {
          return $scope.type = "alert-info";
        } else if (val === 2) {
          return $scope.type = "alert-warning";
        } else if (val === 3) {
          return $scope.type = "alert-danger";
        }
      });
      $scope.calculateOOOutput = function(Income1, Income2) {
        return demoService.calculateOOOutput(Income1, Income2).then(function(ret) {
          return $scope.OOOOuput = ret;
        });
      };
      $scope.calculateEPPlusOutput = function(Income1, Income2) {
        return demoService.calculateEPPlusOutput(Income1, Income2).then(function(ret) {
          return $scope.EPOuput = ret;
        });
      };
      $scope.downloadExcel = function() {
        return demoService.downloadExcel($scope.alerts).then(function(ret) {
          return $scope.EPOuput = ret;
        });
      };
      return $scope.calculateMemoryOutput = function(Income1, Income2) {
        return demoService.calculateMemoryOutput(Income1, Income2).then(function(ret) {
          return $scope.MemoOuput = ret;
        });
      };
    }
  ]);

}).call(this);
