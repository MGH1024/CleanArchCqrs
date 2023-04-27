import {Formik, FormikHelpers} from "formik";
import {Link, useNavigate} from "react-router-dom";
import IRegisterUser from "../types/registerUser";
import {SpanText} from "./components/public/spanText";


const SignUp = () => {
    let history = useNavigate();
    
   

    return (
        <section className="ftco-section">
            <div className="container">
                <div className="row justify-content-center pt-5">
                    <div className="col-md-6 col-lg-4">
                        <div className="login-wrap py-5">
                            <div className="img d-flex align-items-center justify-content-center"></div>
                            <h3 className="text-center mb-0 mb-5">register</h3>
                            <Formik
                                initialValues={{username: '', password: ''}}
                                validate={(values: any) => {
                                    const errors: any = {};
                                    if (!values.username) {
                                        errors.username = "required";
                                    }
                                    if (!values.password) {
                                        errors.password = "required";
                                    }
                                    return errors;
                                }}
                                onSubmit={(
                                    values,
                                    {setSubmitting}: FormikHelpers<IRegisterUser>) => {
                                    setTimeout(() => {
                                        setSubmitting(false);
                                    }, 400);
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
                                    <form onSubmit={handleSubmit} className="signIn-form">
                                        <div className="form-group">
                                            <div
                                                className="icon d-flex align-items-center justify-content-center"></div>
                                            <input
                                                type="text"
                                                className="form-control mb-3"
                                                placeholder="username"
                                                name="username"
                                                onChange={handleChange}
                                                onBlur={handleBlur}
                                                value={values.username}
                                            />
                                            <div className="mt-0 mb-2">
                                                <SpanText
                                                    text={
                                                        errors.username &&
                                                        touched.username &&
                                                        errors.username
                                                    }
                                                    className="text-danger"
                                                />
                                            </div>
                                        </div>

                                        <div className="form-group">
                                            <div
                                                className="icon d-flex align-items-center justify-content-center"></div>
                                            <input
                                                type="password"
                                                className="form-control mb-3"
                                                placeholder="********"
                                                name="password"
                                                onChange={handleChange}
                                                onBlur={handleBlur}
                                                value={values.password}
                                            />
                                            <div className="mt-0 mb-2">
                                                <SpanText
                                                    text={
                                                        errors.password &&
                                                        touched.password &&
                                                        errors.password
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
                                                Register
                                            </button>
                                        </div>
                                    </form>
                                )}
                            </Formik>
                            <div className="w-100 text-center mt-4 text">
                                <p className="mb-0">do you have account ?</p>
                                <Link to="/">login</Link>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
};

export default SignUp;
