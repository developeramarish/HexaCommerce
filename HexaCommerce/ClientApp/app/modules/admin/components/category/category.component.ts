import { Component, OnInit, ViewChild } from '@angular/core';
import { CategoryModel } from './category.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RepositoryService } from '../../../../shared/repository.service';

@Component({
    selector: 'Category',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.css'],
    providers: [RepositoryService]
})
export class CategoryComponent implements OnInit {

    categories: CategoryModel[];
    categoryFrm: FormGroup;

    constructor(private _repositoryService: RepositoryService, private fb: FormBuilder) { }

    ngOnInit() {

        this.categoryFrm = this.fb.group({
            Name: [''],
            Description: ['', Validators.required],
            ParentCategoryId: [''],
            IncludeInNavigation: true,
            Active: true,
            Deleted: false,
            DisplayOrder: ['']
        });

        this._repositoryService.get("/api/admin/category").subscribe(data => {
            this.categories = data
        }, error => {
            if (error) {
                alert("Error")
            }
        });
    }
}
