import React, {useContext, useState} from "react";
import {Dialog, DialogActions, DialogContent, DialogTitle, TextField} from "@mui/material";
import {Button} from "reactstrap";
import {ServiceApi} from "../ServiceApi";
import {AppContext} from "../AppContext";

export function ShipmentDialog({open, onClose}) {
  const [title, setTitle] = useState('');
  const [code, setCode] = useState('');
  const [showSaved, setShowSaved] = useState(false);
  const {triggerReload} = useContext(AppContext);

  const onSave = () => {
    ServiceApi
      .saveShipment(title, code)
      .then(() => setShowSaved(true))
      .then(() => triggerReload());
  };

  return <Dialog open={open} onClose={onClose}>
    <DialogTitle>Create shipment</DialogTitle>
    <DialogContent>
      <div className="dialog-content">
        {!showSaved ? (<>
          <TextField
            label="Code"
            value={code}
            onChange={(e) => setCode(e.target.value)}
          />
          <TextField
            label="Title"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
          />
        </>)
        : <span className="saved">
            Saved
          </span>}
      </div>
    </DialogContent>
    <DialogActions>
      <Button onClick={onClose}>{showSaved ? "Ok" : "Cancel"}</Button>
      {!showSaved && <Button onClick={onSave}>Save</Button>}
    </DialogActions>
  </Dialog>
}