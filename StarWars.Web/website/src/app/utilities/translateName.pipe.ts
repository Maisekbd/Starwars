import { Pipe, PipeTransform } from '@angular/core';
export class TranslateNameModel {
    nameAR: string;
    nameEN: string;
}
@Pipe({ name: 'loadName' })
export class LoadNamePipe implements PipeTransform {
    transform(obj:any, rtlEnabled: boolean) {
        if (rtlEnabled) {
            return obj.nameAR;
        }
        else return obj.nameEN;
    }
}