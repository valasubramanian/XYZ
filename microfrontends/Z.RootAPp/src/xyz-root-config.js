import { registerApplication, start } from "single-spa";

registerApplication({
    name: "@xyz/x-ui",
    app: () => System.import("@xyz/x-ui"),
    activeWhen: ["/"],
});

registerApplication({
  name: "@xyz/y-ui",
  app: () => System.import("@xyz/y-ui"),
  activeWhen: ["/account"],
});

start({
  urlRerouteOnly: true,
});
