import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { LoginModel } from './login.model';

@Injectable()
export class LoginService {
    public token: string;

    constructor(private _http: Http, private _router: Router) { }

    validateLogin(loginModel: LoginModel) {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this._http.post('/api/Login', loginModel, options).
            map((response: Response) => {
                let apiResponse = response.json() && response.json();
                if (apiResponse != null) {
                    localStorage.setItem('currentCustomer', JSON.stringify({ username: loginModel.UserName, token: apiResponse.Token, isAdmin: apiResponse.IsAdmin }));
                    return apiResponse;
                }
                else {
                    return null;
                }
            }).catch(response => {
                console.log(response);
                if (response.status === 401) {
                    this._router.navigate(['Login']);
                }
                return response;
            });
    }

    logoutCustomer() {
        localStorage.removeItem("currentCustomer");
    }
}