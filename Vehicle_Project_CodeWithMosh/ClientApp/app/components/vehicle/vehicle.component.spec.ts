/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { VehicleComponent } from './vehicle.component';

let component: VehicleComponent;
let fixture: ComponentFixture<VehicleComponent>;

describe('Vehicle component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ VehicleComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(VehicleComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});