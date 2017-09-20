(function () {
    //create a module
    var app = angular.module('myApp', []);
    app.controller('myController',
        function ($scope, $http) {



            $http({
                method: "GET",
                url: "/api/Countries"

            })
                .then(function mySucess(response) {
                    $scope.result = response.data;
                },
                    function myError(response) {
                        $scope.Message = response.statusText;
                    });

            $scope.Code =
            {
                CountryCode: ''

            };

            $scope.GetCities = function () {
                var selectedcountry = $scope.selectedCountry.CountryCode;
                $http({
                    method: "GET",
                    url: "/api/Cities/",
                    params: {
                        selectedcountry: selectedcountry
                    }


                })
                   .then(function mySucess(response) {
                       $scope.cityresult = response.data;
                   },
                       function myError(response) {
                           $scope.Message = response.statusText;
                       });

            };

            $scope.Save = function () {
                var selectedcountry = $scope.selectedCountry.CountryName;
                var selectedcity = $scope.selectedcity.CityName;
                var personname = $scope.personname;
                var countrycode = $scope.selectedCountry.CountryCode;
                var citycode = $scope.selectedcity.CityCode;
                $http({
                    method: "POST",
                    url: "/api/Person/",
                    data:
                    {
                        PersonName: personname,
                        SelectedCountry: selectedcountry,
                        SelectedCity: selectedcity,
                        SelectedCountryCode: countrycode,
                        SelectedCityCode: citycode
                    }


                })
                   .then(function mySucess(response) {
                       $scope.personlist = response.data;
                       $scope.Message = "Saved User Successfully";
                   },
                       function myError(response) {
                           $scope.Message = response.statusText;
                       });


            };
            $scope.fnClick = function (usr) {


                //Get all cities and fill to dropdown when user cliks the table

                $http({
                    method: "GET",
                    url: "/api/Cities/"


                })
                   .then(function mySucess(response) {
                       $scope.cityresult = response.data;
                   },
                       function myError(response) {
                           $scope.Message = response.statusText;
                       });


                $http({
                    method: "GET",
                    url: "/api/Person/",
                    params: {
                        id: usr.PersonId
                    }


                })
                   .then(function mySucess(response) {
                       $scope.personresult = response.data;
                   },
                       function myError(response) {
                           $scope.Message = response.statusText;
                       });





            };

            $scope.UpdateUser = function (pid) {
                var selectedcountry = $scope.selectedCountry.CountryName;
                var selectedcity = $scope.selectedcity.CityName;
                var personname = $scope.personname;
                var countrycode = $scope.selectedCountry.CountryCode;
                var citycode = $scope.selectedcity.CityCode;
                var personid = pid;

                $http({
                    method: "PUT",
                    url: "/api/Person/",
                    data:
                        {
                            PersonName: personname,
                            SelectedCountry: selectedcountry,
                            SelectedCity: selectedcity,
                            SelectedCountryCode: countrycode,
                            SelectedCityCode: citycode,
                            PersonId: personid
                        }


                })
                      .then(function mySucess(response) {
                          $scope.personlist = response.data;
                          $scope.Message = "Updated User Successfully";
                      },
                          function myError(response) {
                              $scope.Message = response.statusText;
                          });



            };

            $scope.DeleteUser = function (pid) {

                $http({
                    method: "DELETE",
                    url: "/api/Person/",
                    params:
                        {
                            personid: pid
                        }


                })
                      .then(function mySucess(response) {
                          $scope.personlist = response.data;
                          $scope.Message = "Deleted User Successfully";
                      },
                          function myError(response) {
                              $scope.Message = response.statusText;
                          });

            };

            $scope.Clear = function () {

                $scope.personresult = null;


            };

        });
})();


