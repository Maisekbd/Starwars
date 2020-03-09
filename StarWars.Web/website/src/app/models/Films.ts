import { Deserializable } from './People';

export class Films implements Deserializable {
    public id: number;
    public title: string;
    public count: number;

    constructor(id: number, title: string, count: number ) {
        this.id = id;
        this.title = title;
        this.count = count;
    }

    static deserialize(Res: any): Films {
        return new Films(Res.id, Res.title, Res.count);
    }
    public getDefault() {
        return new Films(0, "",0);
    }
}

