import React, {useEffect, useState} from "react";
import {ServiceApi} from "../ServiceApi";
import {CargoTable} from "./CargoTable";
import {CargoChart} from "./CargoChart";

export function Cargo({cargoId, label}) {
  const [measurements, setMeasurements] = useState([]);

  useEffect(() => {
    ServiceApi.getCargo(cargoId)
      .then(data => setMeasurements(data.measurements));
  }, [cargoId]);

  return <div className="cargo">
    <h3>{label}</h3>
    <div className="cargo-content">
      <CargoChart measurements={measurements}/>
      <CargoTable measurements={measurements}/>
    </div>
  </div>
}