export enum SortTypeEnum {
    Desc = 0,
    Asc = 1
}

export class SortTypeEnumExtensions {

    static SortTypes = [
        { id: SortTypeEnum.Desc, name: "Sắp xếp giảm dần" },
        { id: SortTypeEnum.Asc, name: "Sắp xếp tăng dần" },
    ];
    
    public static GetSelectItems() {
        return this.SortTypes;
    }
    
    public static GetName(value: number) {
        for(let type of this.SortTypes) {
            if(type.id == value) {
                return type.name;
            }
        }
        return null;
    }
}