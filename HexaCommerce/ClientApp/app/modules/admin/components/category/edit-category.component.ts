import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { CategoryModel } from './category.model';
import { CategoryService } from './category.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';


@Component({
    selector: 'editCategory',
    templateUrl: './edit-category.component.html',
    providers: [CategoryService]
})
export class EditCategoryComponent implements OnInit, OnDestroy {

    Category: CategoryModel;
    categoryFrm: FormGroup;
    id: number;
    action: string = "Add";
    private sub: any;

    constructor(private _categoryService: CategoryService, private fb: FormBuilder, private _route: ActivatedRoute) { }

    ngOnInit(): void {

        this.sub = this._route.params.subscribe(params => {
            this.id = +params['id'];
        });

        if (this.id) {
            this.action = "Edit";

            this._categoryService.getCategoryById(this.id).subscribe(data => {
                this.Category = data
                this.categoryFrm = this.fb.group({
                    Id: this.Category.Id,
                    Name: this.Category.Name,
                    Description: [this.Category.Description, Validators.required],
                    ParentCategoryId: [this.Category.ParentCategoryId],
                    IncludeInNavigation: [this.Category.IncludeInNavigation],
                    Active: [this.Category.Active],
                    Deleted: [this.Category.Deleted],
                    DisplayOrder: [this.Category.DisplayOrder]
                });
            }, error => {
                if (error) {
                    alert("Error")
                }
            });

        }
        else {
            this.categoryFrm = this.fb.group({
                Id: 0,
                Name: ['', Validators.required],
                Description: ['', Validators.required],
                ParentCategoryId: [],
                IncludeInNavigation: [true],
                Active: [true],
                Deleted: [false],
                DisplayOrder: [0]
            });
        }
    }

    onSubmit(categoryFrm: CategoryModel) {

        console.log(categoryFrm);

        if (categoryFrm.Id > 0) {
            this._categoryService.updateCategory(categoryFrm).subscribe(
                data => {
                    debugger;
                    console.log(data);

                    if (data.status == 200) {
                        alert("Done");
                    }
                    else {
                        alert("There is some issue in submitting form")
                    }
                }
            );
        }
        else {
            this._categoryService.addCategory(categoryFrm).subscribe(
                data => {
                    if (data.status == 200) {
                        alert("Done");
                    }
                    else {
                        alert("There is some issue in submitting form")
                    }
                }
            );
        }


    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }
}
