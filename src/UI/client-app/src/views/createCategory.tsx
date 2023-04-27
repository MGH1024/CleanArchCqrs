import {Link, useNavigate} from "react-router-dom";
import {Formik, FormikHelpers} from "formik";
import SpanText from "./components/public/spanText";
import {Create} from "../services/partyService";
import CreateCategoryValue from "../types/createCategoryValue";


const CreateParty = () => {
    let history = useNavigate();
    return (
        <section className="ftco-section">
            <div className="container">
                <div className="row justify-content-center pt-5">
                    <div className="col-md-6 col-lg-4">
                        <div className="login-wrap py-5">
                            <div className="img d-flex align-items-center justify-content-center"></div>
                            <h3 className="text-center mb-0 mb-5">create new category</h3>
                            <Formik
                                initialValues={{
                                    code: "",
                                    title: "",
                                    description: ""
                                }}
                                validate={(values: CreateCategoryValue) => {
                                    const errors: any = {};
                                    if (!values.code) {
                                        errors.partyName = "required";
                                    }
                                    if (!values.title) {
                                        errors.email = "required";
                                    }
                                    return errors;
                                }}

                                onSubmit={async (
                                    values,
                                    {setSubmitting}: FormikHelpers<CreateCategoryValue>) => {
                                    setTimeout(() => {
                                        setSubmitting(false);
                                    }, 100);
                                    await Create(values);
                                    history("/main");
                                }}
                            >
                                {({
                                      values,
                                      errors,
                                      touched,
                                      handleChange,
                                      handleBlur,
                                      handleSubmit,
                                      isSubmitting,
                                      /* and other goodies */
                                  }) => (
                                    <form onSubmit={handleSubmit} className="SignIn-form">
                                        <div className="form-group">
                                            <div
                                                className="icon d-flex align-items-center justify-content-center"></div>
                                            <input
                                                type="text"
                                                className="form-control mb-3"
                                                placeholder="code"
                                                name="partyName"
                                                onChange={handleChange}
                                                onBlur={handleBlur}
                                                value={values.code}
                                            />
                                            <div className="mt-0 mb-2">
                                                <SpanText
                                                    text={
                                                        errors.code &&
                                                        touched.code &&
                                                        errors.code
                                                    }
                                                    className="text-danger"
                                                />
                                            </div>
                                        </div>

                                        <div className="form-group">
                                            <div
                                                className="icon d-flex align-items-center justify-content-center"></div>
                                            <input
                                                type="email"
                                                className="form-control mb-3"
                                                placeholder="title"
                                                name="email"
                                                onChange={handleChange}
                                                onBlur={handleBlur}
                                                value={values.title}
                                            />
                                            <div className="mt-0 mb-2">
                                                <SpanText
                                                    text={
                                                        errors.title &&
                                                        touched.title &&
                                                        errors.title
                                                    }
                                                    className="text-danger"
                                                />
                                            </div>
                                        </div>

                                        <div className="form-group">
                                            <div
                                                className="icon d-flex align-items-center justify-content-center"></div>
                                            <input
                                                type="text"
                                                className="form-control mb-3"
                                                placeholder="description"
                                                name="cellphone"
                                                onChange={handleChange}
                                                onBlur={handleBlur}
                                                value={values.description}
                                            />
                                            <div className="mt-0 mb-2">
                                                <SpanText
                                                    text={
                                                        errors.description &&
                                                        touched.description &&
                                                        errors.description
                                                    }
                                                    className="text-danger"
                                                />
                                            </div>
                                        </div>

                                        <div className="form-group">
                                            <button
                                                className="btn form-control btn-primary rounded submit px-3"
                                                disabled={isSubmitting}
                                                type="submit"
                                            >
                                                register
                                            </button>
                                        </div>
                                    </form>
                                )}
                            </Formik>
                            <div className="w-100 text-center mt-4 text">
                                <Link to="/signup">return</Link>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
};

export default CreateParty;
