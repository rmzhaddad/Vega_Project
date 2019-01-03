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
    models: any[]=[];
    features: any[] = [];
    vehicle: any = {
        features: [],
        contact: {}
    };
    

    /** Vehicle ctor */
    constructor(private VehicleService: VehicleService)
        {
        
    }
    ngOnInit() {
        this.VehicleService.getMakes().subscribe(makes => { this.makes = makes; });
        this.VehicleService.getFeatures().subscribe(features => { this.features = features; });
        
    }
    onMakeChange() {// console.log("VEHICLE", this.vehicle); used to check this functionality of function 
        var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
        this.models = selectedMake ? selectedMake.models : [];
        delete this.vehicle.modelId;
    }
    onFeatureToggle(featureId: any, $event: { target: { checked: any; }; }) {
        if ($event.target.checked)
            this.vehicle.features.push(featureId);
        else
        {
            var index = this.vehicle.features.indexOf(featureId);
            this.vehicle.features.splice(index, 1);
        }
    }
    submit() {

        this.VehicleService.create(this.vehicle).subscribe(x => console.log(x));

    }

}