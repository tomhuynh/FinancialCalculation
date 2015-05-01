(function() {
  var module;

  module = angular.module('app');

  module.factory('demoService', [
    'BASE_WEB_API', '$http', '$q', function(BASE_WEB_API, $http, $q) {
      var calculateEPPlusOutput, calculateMemoryOutput, calculateOOOutput, downloadExcel, getAlerts;
      getAlerts = function() {
        return $http.get("" + BASE_WEB_API + "/alerts").then(function(response) {
          return response.data;
        }, function(errorResponse) {
          throw {
            status: errorResponse.status,
            message: errorResponse.data.Message
          };
        });
      };
      calculateOOOutput = function(income1, income2) {
        return $http.get("" + BASE_WEB_API + "/calcOOs/" + income1 + "/" + income2).then(function(response) {
          return response.data;
        }, function(errorResponse) {
          throw {
            status: errorResponse.status,
            message: errorResponse.data.Message
          };
        });
      };
      calculateEPPlusOutput = function(income1, income2) {
        return $http.get("" + BASE_WEB_API + "/calcEps/" + income1 + "/" + income2).then(function(response) {
          return response.data;
        }, function(errorResponse) {
          throw {
            status: errorResponse.status,
            message: errorResponse.data.Message
          };
        });
      };
      calculateMemoryOutput = function(income1, income2) {
        return $http.get("" + BASE_WEB_API + "/calcMemo/" + income1 + "/" + income2).then(function(response) {
          return response.data;
        }, function(errorResponse) {
          throw {
            status: errorResponse.status,
            message: errorResponse.data.Message
          };
        });
      };
      downloadExcel = function(users) {
        var url;
        url = "http://localhost:85/web";
        return $http.post("" + url + "/abc/calcEps").then(function(response) {
          return response.data;
        }, function(errorResponse) {
          throw {
            status: errorResponse.status,
            message: errorResponse.data.Message
          };
        });
      };
      return {
        getAlerts: getAlerts,
        calculateOOOutput: calculateOOOutput,
        calculateEPPlusOutput: calculateEPPlusOutput,
        downloadExcel: downloadExcel,
        calculateMemoryOutput: calculateMemoryOutput
      };
    }
  ]);

}).call(this);
