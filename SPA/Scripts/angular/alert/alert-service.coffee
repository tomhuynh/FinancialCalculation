module = angular.module 'app'
module.factory 'demoService', ['BASE_WEB_API', '$http', '$q', (BASE_WEB_API,$http, $q) ->

    getAlerts = ->
        $http.get("#{BASE_WEB_API}/alerts").then (response) ->
            response.data
        , (errorResponse) ->
            throw { 
                status:  errorResponse.status
                message: errorResponse.data.Message
            }
            
    calculateOOOutput = (income1, income2) ->
        $http.get("#{BASE_WEB_API}/calcOOs/#{income1}/#{income2}").then (response) ->
            response.data
        , (errorResponse) ->
            throw { 
                status:  errorResponse.status
                message: errorResponse.data.Message
            }
            
    calculateEPPlusOutput = (income1, income2) ->
        $http.get("#{BASE_WEB_API}/calcEps/#{income1}/#{income2}").then (response) ->
            response.data
        , (errorResponse) ->
            throw { 
                status:  errorResponse.status
                message: errorResponse.data.Message
            }

    calculateMemoryOutput = (income1, income2) ->
        $http.get("#{BASE_WEB_API}/calcMemo/#{income1}/#{income2}").then (response) ->
            response.data
        , (errorResponse) ->
            throw { 
                status:  errorResponse.status
                message: errorResponse.data.Message
            }
                        
    downloadExcel = (users) ->
        url = "http://localhost:85/web"               
        $http.post("#{url}/abc/calcEps").then (response) ->
            response.data
        , (errorResponse) ->
            throw { 
                status:  errorResponse.status
                message: errorResponse.data.Message
            }
            
            
    {
        getAlerts: getAlerts 
        calculateOOOutput: calculateOOOutput
        calculateEPPlusOutput: calculateEPPlusOutput
        downloadExcel: downloadExcel
        calculateMemoryOutput: calculateMemoryOutput
    }
] 