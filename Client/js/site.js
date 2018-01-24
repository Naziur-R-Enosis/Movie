/// <reference path="angular.min.js"/>
var tempo = [];

var app = angular
    .module("MovieModule", ["ngRoute"])
    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        
        $routeProvider
            .when("/routeIndex", {
                templateUrl: "templates/list.html",
                controller: "MovieController",
                resolve: {
                    Movielist: function ($http) {

                    }
                }
                })  
            .when("/routeEdit/:id", {
                templateUrl: "templates/edit.html",
                controller: "EditController"
            })
            ;

    }])
    .controller("MovieController", function ($scope, $http, Sharedmovie){
       
        $http({
            method: "GET",
            url: "http://localhost:56540/api/values"
        })
            .then(function (response) {
                $scope.movies = response.data;
                Sharedmovie.assign($scope.movies);
            });
        $scope.Getdate = function (date) {
            var temp = "";
            for (var j = 0; j < date.length; j++)
                if (date[j] >= '0' && date[j] <= '9')
                    temp += date[j];
            var val = parseInt(temp);

            return new Date(val);
        };
        var id;
        $scope.getID = function (mID) {
            id = mID;
        };

    })
   
    .controller("EditController", function ($window, $scope, $http, $routeParams, Sharedmovie) {
        var Movie;
        var gt = Sharedmovie.getmovie();

        $scope.user = {};
            $http({
                method: "GET",
                url: "http://localhost:56540/api/values",
                params: { id: $routeParams.id }
            }).then(
                function (response) {
                    Movie = response.data;
                    var temp = "";
                    var date = Movie.ReleaseDate;
                    for (var j = 0; j < date.length; j++)
                        if (date[j] >= '0' && date[j] <= '9')
                            temp += date[j];
                    var val = parseInt(temp);
                    Movie.ReleaseDate = new Date(val);
                    $scope.user = Movie;
                }
                );
            $scope.moviesubmit = function () {
                $http({
                    method: "Post",
                    url: "http://localhost:56540/api/values",
                    data: $scope.user
                }).then(
                    function (response) {
                        alert(response.data);
                        $window.location.href = "#!/routeIndex";
                    }
                    );
            };
  
    })
    .factory("Sharedmovie", function () {
        var temp;
        return {
            assign: assign,
            getmovie: getmovie
        };
       function assign (movie)
        {
           temp = movie;
        }
        function getmovie()
        {
            return temp;
        }
        
    })
    ;