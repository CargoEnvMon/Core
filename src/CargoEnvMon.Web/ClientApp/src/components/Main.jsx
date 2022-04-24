import React, {useContext, useEffect, useState} from 'react';
import {Autocomplete, TextField} from "@mui/material";
import {ServiceApi} from "../ServiceApi";
import {AppContext} from "../AppContext";
import {Cargo} from "./Cargo";

export function Main() {
  const [shipments, setShipments] = useState([]);
  const [cargos, setCargos] = useState([]);
  const [selectedShipment, setSelectedShipment] = useState(null);
  const [selectedCargo, setSelectedCargo] = useState(null);
  
  const {reloadShipments} = useContext(AppContext);
  
  useEffect(() => {
    ServiceApi.getShipments()
      .then(data => {
        const items = data.items.map(({shipmentId, title, code}) => ({label: `${title} (#${code})`, shipmentId}));
        setShipments(items);
      });
  }, [reloadShipments]);
  
  const onShipmentSelect = (e, val) => {
    setSelectedShipment(val);
    if (val) {
      ServiceApi.getCargos(val.shipmentId)
        .then(data => {
          const items = data.items.map(({cargoId, title, code}) => ({label: `${title} (#${code})`, cargoId}));
          setCargos(items);
        })
    }
    setSelectedCargo(null);
  };
  
  const onCargoSelect = (e, val) => {
    setSelectedCargo(val);
  }

  return (
    <div className="main">
      <h1 className="title">Cargo check</h1>
      <div className="selects-wrapper">
        <Autocomplete
          disablePortal
          options={shipments}
          value={selectedShipment}
          onChange={onShipmentSelect}
          sx={{width: 300}}
          renderInput={(params) => <TextField {...params} label="Shipment"/>}
        />
        {selectedShipment && <Autocomplete
          disablePortal
          options={cargos}
          value={selectedCargo}
          onChange={onCargoSelect}
          sx={{width: 300}}
          renderInput={(params) => <TextField {...params} label="Cargo"/>}
        />}
        {selectedCargo && <Cargo {...selectedCargo}/>}
      </div>
    </div>
  );
}

