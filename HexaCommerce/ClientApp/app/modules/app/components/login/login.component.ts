import { Component } from '@angular/core';
import { Router } from '@angular/router'
import { NgProgressService } from 'ng2-progressbar';
import { LoginModel } from './login.model'
import { LoginService } from './login.service';

@Component({
    templateUrl: './login.component.html',
    providers: [LoginService]
})

export class LoginComponent {
    constructor(private _router: Router, private _loginService: LoginService, private progressService: NgProgressService) {
        localStorage.removeItem("registeredCustomer");
        localStorage.removeItem("adminCustomer");
    }

    LoginModel: LoginModel = new LoginModel();
    apiResponse: any;
    status: boolean;

    onSubmit() {

        this.progressService.start();

        var loginModel = this.LoginModel;

        this._loginService.validateLogin(loginModel).subscribe
            (
            data => {
                this.apiResponse = data;
                if (this.apiResponse == null) {
                    alert("Invalid Username and Password");
                }
                else
                {
                    if (this.apiResponse.CustomerTypeIds == '151') {
                        alert("Logged in successfully");
                        this._router.navigate(['Admin']);
                    }
                    else {
                        console.log(this.apiResponse);
                        alert("Logged in Successfully");
                        this._router.navigate(['Home']);
                    }
                }
            },
            err => {
                if (err) {
                    alert("An Error has occured please try again after some time !");
                }
            });

        this.progressService.done();
    }
}

