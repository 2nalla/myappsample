function sGradesJs($scope, $http) {
    $scope.sGrade = {
        StudentCode: "",
        StudentName: "",
        Math: +(0),
        Science: +(0),
        English: +(0),
        Total: +(0),
        Average:+(0),
        Grade: ""
        //emptyData: function () {
        //    this.StudentCode = "",
        //    this.StudentName = "",
        //    this.Math = "",
        //    this.Science = "",
        //    this.English = ""
        //}
        //calculateTA: function() {
        //    this.Total = this.Math + this.Science +this.English;
        //    this.Average = this.Total/3;
        //    if (this.Average >= 70) {
        //           this.Grade = "P";
        //        }
        //        else {
        //           this.Grade = "F";
        //         }
        //    }
    };
    $scope.addmssg = "";
    $scope.updatemssg = "";
    $scope.deletemssg = "";
    $scope.StudentsGrades = {};

    

    $scope.Load = function () {
        $http.get("Api/CtrStudentGrades")
        .then(function (response) {
            $scope.StudentsGrades = response.data;
           
            $scope.sGrade = {
                StudentCode: "",
                StudentName: "",
                Math:"",
                Science: "",
                English: ""
                
            }
        });
    }

    $scope.Load();


    $scope.Submit = function () {
        //$scope.sGrade.calculateTA();
        var grade = $scope.sGrade;
        grade.Total = grade.Math+grade.Science+grade.English;
        grade.Average = parseInt(grade.Total / 3);
        if (grade.Average >= 70) {
            grade.Grade = "P";
        }
        else {
            grade.Grade = "F";
        }
       
        $http.post("Api/CtrStudentGrades", grade)
       .then(function (response) {
           if (response.data) {
               
               var grades = response.data;
               //for (var i = 0; i < grades.length; i++) {
               //    grades[i].Total = grades[i].Math+grades[i].Science+grades[i].English;
               //}
               $scope.StudentsGrades = grades;
              
                   $scope.sGrade = {
                       StudentCode: "",
                       StudentName: "",
                       Math: "",
                       Science: "",
                       English: ""
                       
                   }
               $scope.addmssg = "Record Successfully Added!!";
               $scope.updatemssg = "";
               $scope.deletemssg = "";
           }
       });
    }

    $scope.LoadByCode = function (StudentCode) {
        $http.get("Api/CtrStudentGrades?StudentCode="+StudentCode)
        .then(function (response) {
            $scope.sGrade = response.data[0];
            
        });
    }
   
    $scope.LoadByName = function () {
        $http.get("Api/CtrStudentGrades?StudentName="+$scope.sGrade.StudentName)
        .then(function (response) {
            $scope.StudentsGrades = response.data;

        });
    }

    $scope.Update = function () {
        //$scope.sGrade.calculateTA();
        var grade = $scope.sGrade;
        grade.Total = grade.Math + grade.Science + grade.English;
        grade.Average = parseInt(grade.Total / 3);
        if (grade.Average >= 70) {
            grade.Grade = "P";
        }
        else {
            grade.Grade = "F";
        }

        $http.put("Api/CtrStudentGrades", grade)
       .then(function (response) {
           if (response.data) {

               var grades = response.data;
               //for (var i = 0; i < grades.length; i++) {
               //    grades[i].Total = grades[i].Math+grades[i].Science+grades[i].English;
               //}
               $scope.StudentsGrades = grades;
               // $scope.sGrade.emptyData();
               $scope.sGrade = {
                   StudentCode: "",
                   StudentName: "",
                   Math: "",
                   Science: "",
                   English: ""
               }
               $scope.addmssg = "";
               $scope.updatemssg = "Record Successfully Updated!!";
               $scope.deletemssg = "";
           }
       });
    }

}