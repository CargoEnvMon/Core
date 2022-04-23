import React, {createContext, useState} from "react";

export const AppContext = createContext({
  reloadShipments: 0, triggerReload: () => {
  }
})

export function AppContextProvider({children}) {
  const [reloadShipments, setReloadShipments] = useState(0);

  return <AppContext.Provider value={{
    reloadShipments,
    triggerReload: () => setReloadShipments(reloadShipments + 1)
  }}>
    {children}
  </AppContext.Provider>
}