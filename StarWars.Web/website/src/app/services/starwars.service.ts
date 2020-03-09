import { Injectable, Inject, HostBinding, ElementRef } from '@angular/core';
import { Subject, BehaviorSubject, Subscription } from 'rxjs';
import { APP_CONFIG, AppConfig } from '../app-config.module';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { filter } from 'rxjs/operators';
import { tap, map } from 'rxjs/operators';
import { People } from '../models/People';
import { Films } from '../models/Films';


@Injectable({ providedIn: 'root' })
export class StarwarsService {

    private starwarsUrl: string = `https://localhost:44314/api/Starwars/`;

    constructor(@Inject(APP_CONFIG) private config: AppConfig,
        private httpClient: HttpClient) { }

    public GetLongestOpeningCrawl() {
        return this.httpClient.get<Films>(this.starwarsUrl + `GetLongestOpeningCrawl`, {
            //headers: new HttpHeaders({ "Content-Type": "application/json" })
        }).pipe(map((data) => {
            let films: Films;
            films = Films.deserialize(data);
            return films;

        }
        ))
    }


    public GetMostAppeared() {
        return this.httpClient.get<People[]>(this.starwarsUrl + `GetMostAppeared`, {
            //headers: new HttpHeaders({ "Content-Type": "application/json" })
        }).pipe(map((peopledata) => {
            const peopleLst: People[] = [];
            for (let person of peopledata) {
                person = People.deserialize(person);
                peopleLst.push(person);
            }
            return peopleLst;
        }
        ))
    }

    public GetSpicesApperedCountInFilm() {
        return this.httpClient.get<any[]>(this.starwarsUrl + `GetSpicesApperedCountInFilm`, {
            //headers: new HttpHeaders({ "Content-Type": "application/json" })
        }).pipe(map((data) => {
            const filmLst: Films[] = [];
           
            for (let item of data) {
                let film: Films = new Films(0, "", 0);
                film.title = item.speciesName;
                film.count = item.apperedCount;
                filmLst.push(film);
            }
            return filmLst;
        }
        ))
    }

    public GetPilotsProvidedByPlant() {
        return this.httpClient.get<any[]>(this.starwarsUrl + `GetPilotsProvidedByPlant`, {
            //headers: new HttpHeaders({ "Content-Type": "application/json" })
        }).pipe(map((data) => {
            const filmLst: Films[] = [];

            for (let item of data) {
                let film: Films = new Films(0, "", 0);
                film.title = item.plantName;
                film.count = item.pilotCount;
                filmLst.push(film);
            }
            return filmLst;
        }
        ))
    }
  
}