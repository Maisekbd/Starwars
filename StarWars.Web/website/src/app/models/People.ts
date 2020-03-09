
export class People implements Deserializable {
    public id: number;
    public name: string;
    public creationDate: Date;

    constructor(id: number, name: string) {
        this.id = id;
        this.name = name;
    }

    static deserialize(Res: any): People {
        return new People(Res.id, Res.name);
    }
    public getDefault() {
        return new People(0, "");
    }
}

export abstract class Deserializable {
    static deserialize(input: any): Deserializable {
        return;
    }
}
