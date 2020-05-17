import { UserPostEnum, SortTypeEnum } from '';
export class CategoryDto{
    "PrefixIds": number;
    "Id": number;
    "Title": string;
    "ShortDescription": string;
    "ParentId": number;
    "Order": number;
    "IsDisplay": boolean;
    "LimitMinTags": number;
    "DefaultFieldSortOrder": string;
    "UserPost": number;
    "SortType": number;
    "NiceUrl": string;
    "Level": number;

    constructor() {
        this.SortType = SortTypeEnum.Desc;
        this.UserPost = UserPostEnum.All;
        this.IsDisplay = true;
    }
}