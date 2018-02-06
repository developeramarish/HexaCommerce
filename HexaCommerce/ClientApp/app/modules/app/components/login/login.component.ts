import { Component } from '@angular/core';
import { Router } from '@angular/router'
import { LoginModel } from './login.model'
import { LoginService } from './login.service';

@Component({
    templateUrl: './login.component.html',
    providers: [LoginService],
})

export class LoginComponent {
    constructor(private _router: Router,
        private _loginService: LoginService) {

        if (typeof window !== 'undefined') {
            localStorage.removeItem("currentCustomer");
        }
    }

    LoginModel: LoginModel = new LoginModel();
    apiResponse: any;
    status: boolean;
    errorMessage: string;
    successMessage: string;

    onSubmit() {

        var loginModel = this.LoginModel;

        this._loginService.validateLogin(loginModel).subscribe
            (
            data => {
                this.apiResponse = data;
                if (this.apiResponse == null) {
                    this.errorMessage = "Invalid Username and Password";

                }
                else {
                    this.successMessage = "Logged in Successfully";
                    this._router.navigate(['Home']);

                }
            },
            err => {
                if (err) {
                    this.errorMessage = "Invalid Username and Password";
                }
            });
    }
}

