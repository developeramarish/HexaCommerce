import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class RepositoryService {

    private token: string = "";
    private userJson: any;

    constructor(private _http: Http, private _router: Router) {
        this.userJson = localStorage.getItem('currentCustomer');
        this.token = this.userJson !== null ? JSON.parse(this.userJson).token : null;
    }

    public get = (apiUrl: string): Observable<any> => {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Token', this.token);

        let options = new RequestOptions({ headers: headers });
        return this._http.get(apiUrl, options)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

    public getById = (id: number, apiUrl: string): Observable<any> => {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Token', this.token);

        let options = new RequestOptions({ headers: headers });
        return this._http.get(apiUrl + id, options)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

    public post = (model: any, apiUrl: string): Observable<any> => {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Token', this.token);
        let body = JSON.stringify(model);

        let options = new RequestOptions({ headers: headers });
        return this._http.post("admin/api/Category/", body, options)
            .map((response: Response) => response)
            .catch(this.handleError);
    }

    public put = (model: any, apiUrl: string): Observable<any> => {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Token', this.token);
        let body = JSON.stringify(model);

        let options = new RequestOptions({ headers: headers });
        return this._http.put(apiUrl, body, options)
            .map((response: Response) => response)
            .catch(this.handleError);
    }

    public delete = (id: number, apiUrl: string): Observable<any> => {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Token', this.token);

        let options = new RequestOptions({ headers: headers });
        return this._http.delete(apiUrl + id, options)
            .map((response: Response) => response)
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        if (error.status === 401) {
            localStorage.removeItem("currentCustomer");
            this._router.navigate(["Login"]);
        }
        return "Error";
    }
}
