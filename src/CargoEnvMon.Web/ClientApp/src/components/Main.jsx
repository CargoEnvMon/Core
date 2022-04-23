import React, {useContext, useEffect, useState} from 'react';
import {Autocomplete, TextField} from "@mui/material";
import {ServiceApi} from "../ServiceApi";
import {AppContext} from "../AppContext";

export function Main() {
  const [shipments, setShipments] = useState([]);
  const [selectedShipment, setSelectedShipment] = useState(null);
  
  const {reloadShipments} = useContext(AppContext);
  
  useEffect(() => {
    ServiceApi.getShipments()
      .then(data => {
        const items = data.items.map(({shipmentId, title, code}) => ({label: `${title} (#${code})`, shipmentId}));
        setShipments(items);
      });
  }, [reloadShipments]);

  return (
    <div className="main">
      <h1 className="title">Cargo check</h1>
      <div className="selects-wrapper">
        <Autocomplete
          disablePortal
          options={shipments}
          value={selectedShipment}
          onChange={(e, val) => setSelectedShipment(val)}
          sx={{width: 300}}
          renderInput={(params) => <TextField {...params} label="Select shipment"/>}
        />
      </div>
    </div>
  );
}

