import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../../services/vehicle.service';


@Component({
    selector: 'app-vehicle',
    templateUrl: './vehicle.component.html',
    styleUrls: ['./vehicle.component.css']
})
/** Vehicle component*/
export class VehicleComponent implements OnInit {
    makes: any[] =[];
    vehicle: any = {};
    models: any[]=[];
    features: any[] = [];

    /** Vehicle ctor */
    constructor(private VehicleService: VehicleService)
        {
        
    }
    ngOnInit() {
        this.VehicleService.getMakes().subscribe(makes => { this.makes = makes; });
        this.VehicleService.getFeatures().subscribe(features => { this.features = features; });
        
    }
    onMakeChange() {// console.log("VEHICLE", this.vehicle); used to check this functionality of function 
        var selectedMake = this.makes.find(m => m.id == this.vehicle.make);
        this.models = selectedMake ? selectedMake.models : [];
    }
}