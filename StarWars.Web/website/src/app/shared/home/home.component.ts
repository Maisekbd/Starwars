import { Component, OnInit, NgZone, AfterViewInit, OnDestroy } from "@angular/core";
import { StarwarsService } from '../../services/starwars.service';
import { takeUntil } from 'rxjs/operators';
import { People } from '../../models/People';
import { Subject } from 'rxjs';
import { Films } from '../../models/Films';


@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, AfterViewInit, OnDestroy {
    destroy$: Subject<boolean> = new Subject<boolean>();
    filmsData: Films = new Films(0, "", 0);
    spicesData: Films[];
    PlantPilots: Films[];
    mostApearedData: People[];
    show: boolean = false;
    constructor(private zone: NgZone,
        private starwarsService: StarwarsService) { }

    ngOnInit() { }

    ngAfterViewInit() {


    }

    ngOnDestroy() {

    }

    handleClick(event: Event) {
        this.starwarsService.GetLongestOpeningCrawl().pipe(takeUntil(this.destroy$)).subscribe((film) => {
            this.filmsData = film;
        });

        this.starwarsService.GetMostAppeared().pipe(takeUntil(this.destroy$)).subscribe((data) => {
            this.mostApearedData = data;
        });

        this.starwarsService.GetSpicesApperedCountInFilm().pipe(takeUntil(this.destroy$)).subscribe((data) => {
            this.spicesData = data;
        });

        this.starwarsService.GetPilotsProvidedByPlant().pipe(takeUntil(this.destroy$)).subscribe((data) => {
            this.PlantPilots = data;
        });
        this.show = !this.show;
    }
}
