export class CategoryModel {
    public Id: number;
    public Name: string;
    public Description: string;
    public PictureUrl: string;
    public ParentCategoryId: number;
    public IncludeInNavigation: boolean;
    public Active: boolean;
    public Deleted: boolean;
    public DisplayOrder: number;
    public CreatedOn: Date;
}

