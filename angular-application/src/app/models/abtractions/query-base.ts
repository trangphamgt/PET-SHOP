export class QueryBase {
    public Filter: string;
    public OrderBy: string;
    public Direction: number;
    public PageIndex: number;
    public PageSize: number;
    public ShowTotal: boolean;

    constructor() {
        this.Filter = "";
        this.PageIndex = 0;
        this.PageSize = 0;
    }
}