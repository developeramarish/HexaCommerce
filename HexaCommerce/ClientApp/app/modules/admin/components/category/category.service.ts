import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { CategoryModel } from './category.model';

@Injectable()
export class CategoryService {

    private token: string = "";
    private userJson: any;

    constructor(private _http: Http, private _router: Router)
    {
        this.userJson = localStorage.getItem('currentCustomer');
        this.token = this.userJson !== null ? JSON.parse(this.userJson).token :  null;
    }

    public GetAllCategories = (): Observable<any> =>
    {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Token', this.token);

        let options = new RequestOptions({ headers: headers });
        return this._http.get("admin/api/Category", options)
            .map((response: Response) => <any>response.json())
            .catch(response => {
                if (response.status == 401) {
                    this._router.navigate(['Login']);
                }
                return response;
            });
    }

    public GetCategoryById = (id: number): Observable<any> => {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Token', this.token);

        let options = new RequestOptions({ headers: headers });
        return this._http.get("admin/api/Category/" + id, options)
            .map((response: Response) => <any>response.json())
            .catch(response => {
                if (response.status == 401) {
                    this._router.navigate(['Login']);
                }
                return response;
            });
    }
}
