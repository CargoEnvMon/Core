import React, {Component} from 'react';
import {Autocomplete, TextField} from "@mui/material";
import {ServiceApi} from "../ServiceApi";

export class Main extends Component {
  static displayName = Main.name;

  constructor(props) {
    super(props);

    this.state = {
      shipments: [],
      cargos: [],
      selectedShipment: null,
    }
  }

  componentDidMount() {
    ServiceApi.getShipments()
      .then(data => {
        const shipments = data.items.map(({shipmentId, title, code}) => ({label: `${title} (#${code})`, shipmentId}));
        this.setState({shipments});
      });
  }

  render() {
    const {shipments, selectedShipment} = this.state;

    return (
      <div className="main">
        <h1 className="title">Cargo check</h1>
        <div className="selects-wrapper">
          <Autocomplete
            disablePortal
            options={shipments}
            value={selectedShipment}
            onChange={(e, val) => this.setState({selectedShipment: val})}
            sx={{width: 300}}
            renderInput={(params) => <TextField {...params} label="Select shipment"/>}
          />
        </div>
      </div>
    );
  }
}

function getShipments() {

}

